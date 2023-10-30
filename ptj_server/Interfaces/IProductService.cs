using System;
using ptj_server.ViewModels;

namespace ptj_server.Interfaces
{
	public interface IProductService
	{
        // Tim tat ca cac san pham active = true
        public Task<List<ProductViewModel>> findAllActiveProduct();

        // Tim tat ca cac san pham bestseller
        public Task<List<ProductBestSellerViewModel>> findAllBestSellerProduct();

        // Tim tat ca cac san pham homeflag
        public Task<List<ProductViewModel>> findAllHomeFlagProduct();
    }
}

