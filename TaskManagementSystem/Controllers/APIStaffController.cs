using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace TaskManagementSystem.Controllers
{
    public class APIStaffController : ApiController
    {
        private Data.TMSdbmlDataContext db = new Data.TMSdbmlDataContext();

        // ===========
        // Get Item
        // =========== 

        [Route("api/staff/search/{id}")]
        public List<Models.MstStaff> GetItem(String id)
        {
            var isLocked = true;

            var ID = Convert.ToInt32(id);
            var item = from d in db.mstStaffs
                       where d.Id == ID
                       select new Models.MstStaff
                       {
                           Id = d.Id,
                           StaffName = d.StaffName,
                           ContactNumber = d.ContactNumber,
                           IsLocked = isLocked
                       };

            return item.ToList();
        }
        // ===========
        // LIST Item
        // =========== 
        [Route("api/staff/list")]
        public List<Models.MstStaff> Get()
        {
            var isLocked = true;

            var staff = from d in db.mstStaffs
                        select new Models.MstStaff
                        {
                            Id = d.Id,
                            StaffName = d.StaffName,
                            ContactNumber = d.ContactNumber,
                            IsLocked = isLocked


                        };

            return staff.ToList();
        }

        // ===========
        // ADD Item
        // ===========
        [Route("api/staff/add")]
        public HttpResponseMessage Post(Models.MstStaff item)
        {
            try
            {
                var isLocked = true;
                var identityUserId = User.Identity.GetUserId();
                var date = DateTime.Now;

                Data.mstStaff newItem = new Data.mstStaff();

                newItem.StaffName = item.StaffName != null ? item.StaffName : "00000";
                newItem.ContactNumber = item.ContactNumber != null ? item.ContactNumber : "00000";
                newItem.IsLocked = isLocked != null ? isLocked : false;

                //ALLOW NULL

                db.mstStaffs.InsertOnSubmit(newItem);
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
        [Route("api/staff/update/{id}")]
        public HttpResponseMessage Put(String id, Models.MstStaff item)
        {
            try
            {
                var isLocked = true;
                var identityUserId = User.Identity.GetUserId();
                //var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                var itemId = Convert.ToInt32(id);
                var items = from d in db.mstStaffs where d.Id == itemId select d;

                if (items.Any())
                {
                    var updateItem = items.FirstOrDefault();

                    updateItem.StaffName = item.StaffName;
                    updateItem.ContactNumber = item.ContactNumber;
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
        [Route("api/staff/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {

            try
            {
                var staffId = Convert.ToInt32(id);
                var staffs = from d in db.mstStaffs where d.Id == staffId select d;

                if (staffs.Any())
                {
                    db.mstStaffs.DeleteOnSubmit(staffs.First());
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
