using MyBlogger.Core.DTO;
using MyBlogger.Core.Repository;
using MyBlogger.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlogger.Infra.Service
{
   public  class DTOService : IDTOService
    {
        private readonly IDTORepository _dTORepository;
        public DTOService(IDTORepository dTORepository)
        {
            _dTORepository = dTORepository;
        }
        //Get Recent  5 Comment with User name and his image
        public List<GetRecentComment>GetRecentComments()
        {
            return _dTORepository.GetRecentComments();
        }

        //Find the titles of all posts that have Excellent ratings.(stares= 5 or 4
        public List<PostWithGoodReview> PostWithGoodReview()
        {
            return _dTORepository.PostWithGoodReview();


        }

        //Find the titles of all posts that have no ratings.(stares= null)*/ 
        public List<PostWithNullReview> PostWithNullReview()
        {
            return _dTORepository.PostWithNullReview();
        }
        //Search posts by User name or by category title or by post title
        public List<SearchData1>Search(string search)
        {
            return _dTORepository.Search(search);
        }
        //Git The Maximum Rating  And Minimum Rating For Post By its Id or Title 
        public List<GitMaxAndMinRatinByPostTitleORId> GitMaxAndMinRatinByPostTitleORId(string search)  
        {
            return _dTORepository.GitMaxAndMinRatinByPostTitleORId(search);
        }

        //Git The Count of Positive Rating (4-5) Post By its Id or Title 
        public List<GitCountOfPostiveReviewsByIdOrTitle> GitCountOfPostiveReviewsByIdOrTitle(string search)
        {
            return _dTORepository.GitCountOfPostiveReviewsByIdOrTitle(search);
        }

        //procedure to get the  post has maximum number of rating by useres*/
        public List<MaxPostHasReview> MaxPostHasReview()
        {
            return _dTORepository.MaxPostHasReview();
        }

        //Search posts by User name or by category title or by post title ((For Clients))
        public List<SearchPostsByClients> SearchAboutPostsByUserNameOrPostTitleOrCategoryTitle(string search)
        {
            return _dTORepository.SearchAboutPostsByUserNameOrPostTitleOrCategoryTitle(search);
        }

        //Client Can Display Posts Details 
        public List<DisplayPostDetails> UserDisplayPostDetails(int id)
        {
            return _dTORepository.UserDisplayPostDetails(id);
        }

        //Posts User Liked
        public List<PostUserLiked> GetPostUserliked(int id)
        {
            return _dTORepository.GetPostUserliked(id);
        }


        // Display All Posts image and category and user( name and image ) JOIN
        public List<DisplayAllPosts> DisplayAllPosts()
        {
            return _dTORepository.DisplayAllPosts();
        }

        // Display each post with each comments by Id
        public List<DisplayPostComments> DisplayPostComments(int id)
        {
            return _dTORepository.DisplayPostComments(id);
        }

        public List<GetLastesPost> GetLastesPost()
        {
            return _dTORepository.GetLastesPost();
        }

        public List<DisplayAllPostUser> DisplayAllPostUser(int id)

        {
            return _dTORepository.DisplayAllPostUser(id);
        }
    }
}
