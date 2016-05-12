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
        // Get Item
        // =========== 

        [Route("api/product/search/{id}")]
        public List<Models.MstProduct> GetItem(String id)
        {
            var isLocked = true;

            var ID = Convert.ToInt32(id);
            var item = from d in db.mstProducts
                       where d.Id == ID
                       select new Models.MstProduct
                       {
                           Id = d.Id,
                           ProductCode = d.ProductCode,
                           ProductDescription = d.ProductDescription,
                           IsLocked = isLocked
                       };

            return item.ToList();
        }

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

        // ===========
        // ADD Item
        // ===========
        [Route("api/product/add")]
        public HttpResponseMessage Post(Models.MstProduct item)
        {
            try
            {
                var isLocked = true;
                var identityUserId = User.Identity.GetUserId();
                var date = DateTime.Now;

                Data.mstProduct newItem = new Data.mstProduct();

                newItem.ProductCode = item.ProductCode != null ? item.ProductCode : "00000";
                newItem.ProductDescription = item.ProductDescription != null ? item.ProductDescription : "00000";
                newItem.IsLocked = isLocked != null ? isLocked : false;

                //ALLOW NULL

                db.mstProducts.InsertOnSubmit(newItem);
                db.SubmitChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // ==============
        // UPDATE Item
        // ==============
        [Route("api/product/update/{id}")]
        public HttpResponseMessage Put(String id, Models.MstProduct item)
        {
            try
            {
                var isLocked = true;
                var identityUserId = User.Identity.GetUserId();
                //var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                var itemId = Convert.ToInt32(id);
                var items = from d in db.mstProducts where d.Id == itemId select d;

                if (items.Any())
                {
                    var updateItem = items.FirstOrDefault();

                    updateItem.ProductCode = item.ProductCode;
                    updateItem.ProductDescription = item.ProductDescription;
                    updateItem.IsLocked = isLocked;

                    //updateItem.UpdateUserId = 123;
                    //updateItem.UpdateDateTime = date;
                    //updateItem.IsLocked = isLocked;

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
