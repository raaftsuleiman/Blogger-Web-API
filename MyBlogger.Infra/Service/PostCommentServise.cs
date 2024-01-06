using MyBlogger.API.Core.Data;
using MyBlogger.Core.Repository;
using MyBlogger.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Infra.Service
{
    public class PostCommentServise : IPostCommentServise
    {
        private readonly IPostCommentRepository _postCommentRepository;
        public PostCommentServise(IPostCommentRepository postCommentRepository)
        {
            _postCommentRepository = postCommentRepository;
        }
        //Function to Get Count Of All Comments 

        public int CountOfComments()
        {
            return _postCommentRepository.CountOfComments();
        }


        //Function to Get All Comment
        public List<PostComment> GetAllComments()
        {
            return _postCommentRepository.GetAllComments();
        }

        //Function To Create Anew PostComment
        public bool CreateComment(PostComment postComment)
        {
            return _postCommentRepository.CreateComment(postComment);
        }


        //Function To Edite PostComment Record 

        public bool UpdateComment(PostComment postComment)
        {
            return _postCommentRepository.UpdateComment(postComment);
        }

        //Function To Delete Comment Record 
        public bool DeleteComment(int id)
        {
            return _postCommentRepository.DeleteComment(id);
        }


        //Function To Update User's Comments
        public bool UserUpdateHisComment(PostComment postComment)
        {
            return _postCommentRepository.UserUpdateHisComment(postComment);
        }

        //Function To Get Count Of Comment On Posts
        public int CountOfPostComment(int id)
        {
            return _postCommentRepository.CountOfPostComment(id);
        }

        public List<PostComment> GetCommentByUserIdAndPostId(int userid, int postid)
        {
            return _postCommentRepository.GetCommentByUserIdAndPostId(userid, postid);
        }
        public bool UserDeleteHisComment(int UserId, int PostId)
        {
            return _postCommentRepository.UserDeleteHisComment( UserId, PostId);

        }
    }
}
