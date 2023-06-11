using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Product;

namespace Business.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetProducts();
    }
}
