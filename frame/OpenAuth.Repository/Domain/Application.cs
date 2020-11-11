﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
//     Author:Yubao Li
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenAuth.Repository.Domain
{
    /// <summary>
	/// 应用
	/// </summary>
    public partial class Application : Entity
    {
        public Application()
        {
          this.Name= string.Empty;
          this.AppSecret= string.Empty;
          this.Description= string.Empty;
          this.Icon= string.Empty;
          this.CreateTime= DateTime.Now;
          this.CreateUser= string.Empty;
        }

        /// <summary>
	    /// 应用名称
	    /// </summary>
        public string Name { get; set; }
        /// <summary>
	    /// 应用密钥
	    /// </summary>
        public string AppSecret { get; set; }
        /// <summary>
	    /// 应用描述
	    /// </summary>
        public string Description { get; set; }
        /// <summary>
	    /// 应用图标
	    /// </summary>
        public string Icon { get; set; }
        /// <summary>
	    /// 是否可用
	    /// </summary>
        public bool Disable { get; set; }
        /// <summary>
	    /// 创建日期
	    /// </summary>
        public System.DateTime CreateTime { get; set; }
        /// <summary>
	    /// 创建人
	    /// </summary>
        public string CreateUser { get; set; }

    }
}