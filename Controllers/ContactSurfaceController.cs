using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.XPath;
using Umbraco.Core.Services;
using Umbraco.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ContactSurfaceController : SurfaceController
    {
        public ActionResult ShowForm()
        {
            ContactModel myModel = new ContactModel();
            List<SelectListItem> ListOfGenders = new List<SelectListItem>();
            XPathNodeIterator iterator = umbraco.library.GetPreValues(1112);//id yi umbracodan aldik olusturdugumuz datatypein id si url de yaziyo
            iterator.MoveNext();//sifirdan basladigi icin bir sonrakini aliyoruz 1i
            XPathNodeIterator preValues = iterator.Current.SelectChildren("preValue", "");
            
            while (preValues.MoveNext())
            {
                string preValue = preValues.Current.Value;
                ListOfGenders.Add(new SelectListItem
                {
                    Text = preValue,
                    Value = preValue
                });
                myModel.ListOfGenders = ListOfGenders;
            }

            return PartialView("ContactForm", myModel);
        }

        public ActionResult HandleFormPost(ContactModel model)
        {
            var newComment = Services.ContentService.CreateContent(model.Name + "-" + DateTime.Now.ToString("dd/MMMM/yyyy HH:mm.ss"), CurrentPage.Id, "contactFormula");
            var myService = ApplicationContext.Services.DataTypeService;
            var SelectedGender = myService.GetAllDataTypeDefinitions().First(x => x.Id == 1112);
            int SelectedGenderPreValueId = myService.GetPreValuesCollectionByDataTypeId(SelectedGender.Id).PreValuesAsDictionary.Where(x => x.Value.Value == model.SelectedGender).Select(x => x.Value.Id).First();
            newComment.SetValue("dropdownGenders", SelectedGenderPreValueId);
            newComment.SetValue("emailFrom", model.Email);
            newComment.SetValue("contactName", model.Name);
            newComment.SetValue("contactMessage", model.Message);
            Services.ContentService.SaveAndPublishWithStatus(newComment);
            return RedirectToCurrentUmbracoPage();
        }
    }
}