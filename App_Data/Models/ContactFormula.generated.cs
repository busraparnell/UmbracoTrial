//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v3.0.10.102
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder;
using Umbraco.ModelsBuilder.Umbraco;

namespace Umbraco.Web.PublishedContentModels
{
	/// <summary>Contact Formula</summary>
	[PublishedContentModel("contactFormula")]
	public partial class ContactFormula : Master
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "contactFormula";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public ContactFormula(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<ContactFormula, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Contact Message
		///</summary>
		[ImplementPropertyType("contactMessage")]
		public string ContactMessage
		{
			get { return this.GetPropertyValue<string>("contactMessage"); }
		}

		///<summary>
		/// Contact Name
		///</summary>
		[ImplementPropertyType("contactName")]
		public string ContactName
		{
			get { return this.GetPropertyValue<string>("contactName"); }
		}

		///<summary>
		/// Dropdown Genders
		///</summary>
		[ImplementPropertyType("dropdownGenders")]
		public string DropdownGenders
		{
			get { return this.GetPropertyValue<string>("dropdownGenders"); }
		}

		///<summary>
		/// Email From
		///</summary>
		[ImplementPropertyType("emailFrom")]
		public string EmailFrom
		{
			get { return this.GetPropertyValue<string>("emailFrom"); }
		}
	}
}