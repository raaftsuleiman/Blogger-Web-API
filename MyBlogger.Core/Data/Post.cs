using MyBlogger.API.Core.Data;
using System;
using System.Collections.Generic;


namespace MyBlogger.API.Core.Data
{
    public partial class Post
    {
       
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public byte? Published { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string PostContant { get; set; }
        public DateTime? LastModification { get; set; }
        public int? CategoreId { get; set; }
        public int? Userid { get; set; }

        public virtual Category Categore { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<PostComment> PostComments { get; set; }
        public virtual ICollection<PostDetaly> PostDetalies { get; set; }
        public virtual ICollection<PostLike> PostLikes { get; set; }
        public virtual ICollection<PostReview> PostReviews { get; set; }
        public virtual ICollection<PostTage> PostTages { get; set; }
        public virtual ICollection<WebSiteInfo> WebSiteInfos { get; set; }
    }
}
