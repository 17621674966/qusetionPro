using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAuth.Repository.Core
{

    /// <summary>
    /// 懂微办公圈业务系统所有实体的父实体
    /// </summary>
    public abstract class BaseEntity
    {
        #region  公开属性
        [Key]
        [Required]
        [StringLength(50)]
        public string RowGuid { get; set; } = Guid.NewGuid().ToString();

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }
        public string AddUserGuid { get; set; }
        public string AddUserName { get; set; }
        public DateTime? AddTime { get; set; } = DateTime.Now;
        public string LastModifyUserGuid { get; set; }
        public string LastModifyUserName { get; set; }
        public DateTime? LastModifyTime { get; set; } = DateTime.Now;
        public int? RowStatus { get; set; } = 1;
        #endregion
        #region   构造函数
        public BaseEntity()
        {
            RowGuid = Guid.NewGuid().ToString();
            AddTime = DateTime.Now;
            LastModifyTime = DateTime.Now;
            RowStatus = 1;
        }

        #endregion

    }
}
