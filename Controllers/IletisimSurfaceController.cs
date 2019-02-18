using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using WebApp.Models;
using Umbraco.Core.Services;
using System.Xml.XPath;

namespace WebApp.Controllers
{
    public class IletisimSurfaceController : SurfaceController
    {
        public ActionResult Goster()
        {
            IletisimModel yeniModel = new IletisimModel();
            List<SelectListItem> CinsiyetSecimi = new List<SelectListItem>();
            XPathNodeIterator iterator = umbraco.library.GetPreValues(1118);
            iterator.MoveNext();
            XPathNodeIterator preValues = iterator.Current.SelectChildren("preValue", "");
            while (preValues.MoveNext())
            {
                string preValue = preValues.Current.Value;
                CinsiyetSecimi.Add(new SelectListItem()
                {
                    Text = preValue,
                    Value = preValue

                });
                yeniModel.CinsiyetSecimi = CinsiyetSecimi;
            }
            return PartialView("IletisimForm", yeniModel);
        }
        public ActionResult HandleIletisimFormPost(IletisimModel model)
        {
            var yeniKayit = Services.ContentService.CreateContent(model.Name + " " + model.Surname + " " + DateTime.Now.ToString("dd/MMM/yyyy HH:mm.ss") , CurrentPage.Id, "iletisimFormlari");
            yeniKayit.SetValue("pageTitle", CurrentPage.Name);
            yeniKayit.SetValue("siteName", CurrentPage.Parent.Name);
            yeniKayit.SetValue("emailFrom", model.Email);
            yeniKayit.SetValue("nameFrom", model.Name);
            yeniKayit.SetValue("surnameFrom", model.Surname);
            yeniKayit.SetValue("phone", model.Phone);
            yeniKayit.SetValue("message", model.Message);

            IDataTypeService myService = ApplicationContext.Services.DataTypeService;
            var SecilenCinsiyet = myService.GetAllDataTypeDefinitions().First(x => x.Id == 1118);
            int SecilenCinsiyetPreValueId = myService.GetPreValuesCollectionByDataTypeId(SecilenCinsiyet.Id).PreValuesAsDictionary.Where(x => x.Value.Value == model.SecilenCinsiyet).Select(x => x.Value.Id).First();
            yeniKayit.SetValue("cinsiyetSecimi", SecilenCinsiyetPreValueId);

            Services.ContentService.SaveAndPublishWithStatus(yeniKayit);
            return RedirectToCurrentUmbracoPage();
        }

    }
}