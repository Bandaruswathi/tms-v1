using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;


namespace TaskManagementSystem.Controllers
{
    public class APIProductController : ApiController
    {
        private Data.TMSdbmlDataContext db = new Data.TMSdbmlDataContext();

        // ===========
        // LIST Item
        // =========== 
        [Route("api/product/list")]
        public List<Models.MstProduct> Get()
        {
            var isLocked = true;

            var product = from d in db.mstProducts
                        select new Models.MstProduct
                        {
                            Id = d.Id,
                            ProductCode = d.ProductCode,
                            ProductDescription = d.ProductDescription,
                            IsLocked = isLocked
                        };

            return product.ToList();
        }

        // ==============
        // DELETE Item
        // ==============
        [Route("api/product/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {

            try
            {
                var productId = Convert.ToInt32(id);
                var products = from d in db.mstProducts where d.Id == productId select d;

                if (products.Any())
                {
                    db.mstProducts.DeleteOnSubmit(products.First());
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }


    }

    
}
