using MyBlogger.API.Core.Data;
using MyBlogger.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Core.Repository
{
    public interface IDTORepository
    {
        //Get Recent  5 Comment with User name and his image
        public List<GetRecentComment> GetRecentComments();

        //Search posts by User name or by category title or by post title
        public List<SearchData1> Search(string search);
        //Find the titles of all posts that have Excellent ratings.(stares= 5 or 4
        public List<PostWithGoodReview> PostWithGoodReview();
        //Find the titles of all posts that have no ratings.(stares= null)*/ 
        public List<PostWithNullReview> PostWithNullReview();

        //Git The Maximum Rating  And Minimum Rating For Post By its Id or Title 
        public List<GitMaxAndMinRatinByPostTitleORId> GitMaxAndMinRatinByPostTitleORId(string search);

        //Git The Count of Positive Rating (4-5) Post By its Id or Title 
        public List<GitCountOfPostiveReviewsByIdOrTitle> GitCountOfPostiveReviewsByIdOrTitle(string search);

        //procedure to get the  post has maximum number of rating by useres*/
        public List<MaxPostHasReview> MaxPostHasReview();

        //Search posts by User name or by category title or by post title ((For Clients))
        public List<SearchPostsByClients> SearchAboutPostsByUserNameOrPostTitleOrCategoryTitle(string search);

        //Client Can Display Posts Details 
        public List<DisplayPostDetails> UserDisplayPostDetails(int id);

        //Posts User Liked
        public List<PostUserLiked> GetPostUserliked(int id);

        // Display All Posts image and category and user( name and image ) JOIN
        public List<DisplayAllPosts> DisplayAllPosts();

        // Display each post with each comments by Id
        public List<DisplayPostComments> DisplayPostComments(int id);

        public List<GetLastesPost> GetLastesPost();

        public List<DisplayAllPostUser> DisplayAllPostUser(int id);

    }
}
