using MyBlogger.API.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.Repository
{
    public interface IPostCommentRepository
    {
        //Function to Get Count Of All Posts 

        public int CountOfComments();

        //Function to Get All Comments in page
        public List<PostComment> GetAllComments();

        //Function To Create Anew PostComment
        public bool CreateComment(PostComment postComment);


        //Function To Edite PostComment Record 

        public bool UpdateComment(PostComment postComment);

        //Function To Delete Comment Record 
        public bool DeleteComment(int id);


        //Function To Update User's Comments
        public bool UserUpdateHisComment(PostComment postComment);

        //Function To Get Count Of Comment On Posts
        public int CountOfPostComment(int id);

        public List<PostComment> GetCommentByUserIdAndPostId(int userid, int postid);
        public bool UserDeleteHisComment(int UserId, int PostId);




    }
}
