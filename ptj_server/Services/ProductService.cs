using System;
using Microsoft.EntityFrameworkCore;
using ptj_server.DatabaseContext;
using ptj_server.Interfaces;
using ptj_server.ViewModels;

namespace ptj_server.Services
{
	public class ProductService:IProductService
	{
        private DataContext _db;

		public ProductService(DataContext db)
		{
            _db = db;
		}

        public async Task<List<ProductViewModel>> findAllActiveProduct()
        {
            try
            {
                var result = await _db.ProductViewModels.FromSqlRaw("[dbo].[sp_findall_active_product_with_min_price]").ToListAsync();

                return result;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ProductBestSellerViewModel>> findAllBestSellerProduct()
        {
            try
            {
                var result = new List<ProductBestSellerViewModel>();
                var data = await _db.ProductViewModels.FromSqlRaw("[dbo].[sp_findall_best_seller_product_with_min_price]").ToListAsync();

                foreach (var item in data)
                {
                    var itemPro = new ProductBestSellerViewModel();
                    itemPro.id = item.id;
                    itemPro.image = item.image;
                    itemPro.name = item.name;
                    itemPro.price = item.price;
                    itemPro.discount_value = item.discount_value;
                    itemPro.unit = item.unit;
                    itemPro.active = item.active;
                    itemPro.dis_name = item.dis_name;
                    itemPro.is_sold_out = false;

                    if(_db.ProductDetails.Where(i => i.ProductId == item.id).Sum(i => i.Quantity) == 0)
                    {
                        itemPro.is_sold_out = true;
                    }
                    result.Add(itemPro);
                }

                return result;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ProductViewModel>> findAllHomeFlagProduct()
        {
            try
            {
                var result = await _db.ProductViewModels.FromSqlRaw("[dbo].[sp_findall_home_flag_product_with_min_price]").ToListAsync();

                return result;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

