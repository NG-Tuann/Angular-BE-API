using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ptj_server.DatabaseContext;
using ptj_server.Dtos;
using ptj_server.Helpers;
using ptj_server.Interfaces;
using ptj_server.Models;

namespace ptj_server.Services
{
    public class OrderProductService : IOrderProductService
    {
        private readonly DataContext _db;
        private IConfiguration _configuration;

        public OrderProductService(DataContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }

        public async Task<int> processNonCustomerPaypalSuccess(NonCustomerPaypalSuccess result)
        {
            try
            {
                var shipInfo = result.ShipInfo;
                var carts = result.Cart;
                // Tong tien
                double? total = 0;

                // Tinh tong tien
                carts.ToList().ForEach(i =>
                {
                    if((bool)i.IsCheck)
                    {
                        total += (i.SalePrice - i.SavePrice) * i.Quantity;
                        // Cap nhat so luong ton kho
                        var productDetailBought = _db.ProductDetails.ToList().SingleOrDefault(p => p.Id == i.ProductDetailId);
                        productDetailBought.Quantity -= i.Quantity;
                        _db.Update(productDetailBought);
                    }
                });

                _db.SaveChanges();

                // Luu hoa don vao OrderProduct
                var orderProduct = new OrderProduct();
                orderProduct.DateCreated = DateTime.Today;
                orderProduct.CustomerId = null;
                orderProduct.AddressDelivery = shipInfo.Address;
                orderProduct.DatePay = DateTime.Today;
                orderProduct.PayType = "Paypal";
                orderProduct.TotalPay = (decimal)total;
                orderProduct.OrderState = "Chờ xác nhận";
                orderProduct.PhoneNonAccount = shipInfo.Phone;
                orderProduct.MailNonCus = shipInfo.Mail;
                orderProduct.ShipDate = null;
                orderProduct.ShipFee = 0;
                orderProduct.IdUser = null;
                orderProduct.NameCusNonAccount = shipInfo.Fullname;
                orderProduct.PromotionId = null;
                orderProduct.CustomerTypeId = null;

                // Gui mail chua ma don hang
                var guidHelper = new GuidHelper();
                var orderProductId = guidHelper.GenerateOrderCode();
                var mailHelper = new MailHelper(_configuration);

                // Gan ma don hang cho don hang de luu vao db
                orderProduct.OrderProductId = orderProductId;
                string to = shipInfo.Mail;
                string subject = "Đặt hàng thành công tại PTJ";
                string content = "<table style='margin-bottom:20px;' width='100%' border='0' cellspacing='0' cellpadding='0'> <tr> <td align='center' style='text-align: center;'> <img src='https://ijc.vn/vnt_upload/weblink/Logo_IJC__Slogan_1.png' width='220' height='100'> <h1 style='color:#DCB15B;font-size: 40px;margin: 0;'>Đặt hàng thành công</h1> <h3>IJC cám ơn bạn đã tin tưởng chọn và chọn chúng tôi</h3> <p>Bạn đã Đặt hàng thành công, vui lòng sử dụng mã này cho việc theo dõi đơn hàng </p> <p style='font-weight: bolder;'>Mã đơn hàng của bạn là, vui lòng không chia sẽ mã đơn hàng vì lí do bảo mật</p> <span style='color:#DCB15B; border:1px solid #E5E5E5; font-size: 40px; padding: 10px;'>" + orderProduct.OrderProductId + "</span> </td> </tr> </table>";
                string from = "tuan.ng400@aptechlearning.edu.vn";

                // Gui mail
                var mailSender = new MailHelper(_configuration);
                mailSender.SendMailSync(from, to, subject, content);

                // Luu don hang vao db
                _db.OrderProducts.Add(orderProduct);
                _db.SaveChanges();


                // Luu thong tin cac san pham ma khach hang da mua
                foreach (var item in carts)
                {
                    if((bool)item.IsCheck)
                    {
                        var orderDetail = new OrderDetail();
                        orderDetail.OrderId = orderProduct.Id;
                        orderDetail.ProductDetailId = item.ProductDetailId;
                        orderDetail.Quantity = item.Quantity;
                        orderDetail.SalePrice = (int?)item.SalePrice;

                        _db.OrderDetails.Add(orderDetail);
                    }
                }
                return _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return -1;
            }
        }

        public async Task<OrderProduct> trackOrderById(string id)
        {
            var order = await _db.OrderProducts.SingleOrDefaultAsync(i => i.OrderProductId == id);
            return order;
        }
    }
}

