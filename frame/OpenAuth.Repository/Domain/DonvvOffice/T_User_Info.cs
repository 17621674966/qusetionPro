

using OpenAuth.Repository.Core;

namespace OpenAuth.Repository.Domain.DonvvOffice
{
    /// <summary>
    /// 
    /// </summary>
    public class T_User_Info : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public T_User_Info()
        {
        }

        

        private System.String _Name;
        /// <summary>
        /// 用户名
        /// </summary>
        public System.String Name { get { return this._Name; } set { this._Name = value; } }

        private System.String _Tel;
        /// <summary>
        /// 用户电话
        /// </summary>
        public System.String Tel { get { return this._Tel; } set { this._Tel = value; } }

        private System.String _Email;
        /// <summary>
        /// 用户电子邮件
        /// </summary>
        public System.String Email { get { return this._Email; } set { this._Email = value; } }

        private System.String _Address;
        /// <summary>
        /// 用户地址
        /// </summary>
        public System.String Address { get { return this._Address; } set { this._Address = value; } }

        private System.Int32? _Sex;
        /// <summary>
        /// 用户性别（0女 1男）
        /// </summary>
        public System.Int32? Sex { get { return this._Sex; } set { this._Sex = value; } }

        private System.DateTime? _Birthday;
        /// <summary>
        /// 用户出生日期
        /// </summary>
        public System.DateTime? Birthday { get { return this._Birthday; } set { this._Birthday = value; } }

        private System.String _Province;
        /// <summary>
        /// 微信里面的省
        /// </summary>
        public System.String Province { get { return this._Province; } set { this._Province = value; } }

        private System.String _City;
        /// <summary>
        /// 微信里面的
        /// </summary>
        public System.String City { get { return this._City; } set { this._City = value; } }

        private System.String _NickName;
        /// <summary>
        /// 
        /// </summary>
        public System.String NickName { get { return this._NickName; } set { this._NickName = value; } }

        private System.String _AvatarUrl;
        /// <summary>
        /// 
        /// </summary>
        public System.String AvatarUrl { get { return this._AvatarUrl; } set { this._AvatarUrl = value; } }

        private System.String _CompanyGuid;
        /// <summary>
        /// 公司标识
        /// </summary>
        public System.String CompanyGuid { get { return this._CompanyGuid; } set { this._CompanyGuid = value; } }

        private System.String _CompanyName;
        /// <summary>
        /// 公司名称
        /// </summary>
        public System.String CompanyName { get { return this._CompanyName; } set { this._CompanyName = value; } }

        private System.String _DeptName;
        /// <summary>
        /// 部门名称
        /// </summary>
        public System.String DeptName { get { return this._DeptName; } set { this._DeptName = value; } }

        private System.String _Position;
        /// <summary>
        /// 职位名称
        /// </summary>
        public System.String Position { get { return this._Position; } set { this._Position = value; } }

        private System.String _Account;
        /// <summary>
        /// 账号
        /// </summary>
        public System.String Account { get { return this._Account; } set { this._Account = value; } }

        private System.String _Password;
        /// <summary>
        /// 密码
        /// </summary>
        public System.String Password { get { return this._Password; } set { this._Password = value; } }

        private System.String _OpenId;
        /// <summary>
        /// 开放平台ID
        /// </summary>
        public System.String OpenId { get { return this._OpenId; } set { this._OpenId = value; } }

        private System.Boolean? _IsEnable;
        /// <summary>
        /// 账号是否可用
        /// </summary>
        public System.Boolean? IsEnable { get { return this._IsEnable; } set { this._IsEnable = value; } }

        private System.Int32? _IsAuth;
        /// <summary>
        /// 是否公司认证通过(-1，还没有提交资料，0待验证 1验证通过2验证不通过)
        /// </summary>
        public System.Int32? IsAuth { get { return this._IsAuth; } set { this._IsAuth = value; } }

        private System.String _AuthGuid;
        /// <summary>
        /// 当前企业认证Guid
        /// </summary>
        public System.String AuthGuid { get { return this._AuthGuid; } set { this._AuthGuid = value; } }

        private System.Int32? _TotalScore;
        /// <summary>
        /// 当前积分
        /// </summary>
        public System.Int32? TotalScore { get { return this._TotalScore; } set { this._TotalScore = value; } }

        private System.String _LevelContent;
        /// <summary>
        /// 会员等级
        /// </summary>
        public System.String LevelContent { get { return this._LevelContent; } set { this._LevelContent = value; } }

        
    }
}