using Dapper;
using MyBlogger.API.Core.Data;
using MyBlogger.Core.Common;
using MyBlogger.Core.DTO;
using MyBlogger.Core.Repository;
using MyBlogger.Core.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MyBlogger.Infra.Repository
{
   public class DTORepository : IDTORepository
    {
        private readonly IDBcontext _dbcontext;
        public DTORepository(IDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        //Get Recent  5 Comment with User name and his image
        public List<GetRecentComment> GetRecentComments()
        {
            IEnumerable<GetRecentComment>result = _dbcontext.Connection.Query<GetRecentComment>("SELECT TOP 5 u.Fname,u.Image , c.Content FROM  Users u inner join PostComment c on u.Id = c.Userid ORDER BY c.CreateAt ASC", commandType: CommandType.Text);
            return result.ToList();

        }

        //Find the titles of all posts that have Excellent ratings.(stares= 5 or 4
        public List<PostWithGoodReview> PostWithGoodReview()
        {
            IEnumerable<PostWithGoodReview> result = _dbcontext.Connection.Query<PostWithGoodReview>("SELECT p.Id,p.Title as PostTitle ,U.Fname as Bloger ,R.Stars as Rate  FROM Post p inner join PostReview as R on p.Id = R.Postid inner join Users as U on U.Id = P.userid WHERE R.Stars = 4 OR R.Stars = 5", commandType: CommandType.Text);
            return result.ToList();
        }

        //Find the titles of all posts that have no ratings.(stares= null)*/ 
        public List<PostWithNullReview> PostWithNullReview()
        {
            IEnumerable<PostWithNullReview> result = _dbcontext.Connection.Query<PostWithNullReview>("SELECT p.Id,p.Title as PostTitle ,U.Fname as Bloger FROM Post p inner join PostReview as R on p.Id = R.Postid inner join Users as U on U.Id = P.userid WHERE R.Stars is Null", commandType: CommandType.Text);
            return result.ToList();
        }

        //Git The Maximum Rating  And Minimum Rating For Post By its Id or Title 
        public List<GitMaxAndMinRatinByPostTitleORId> GitMaxAndMinRatinByPostTitleORId(string search)
        {
            var p = new DynamicParameters();

            p.Add("@search", search, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<GitMaxAndMinRatinByPostTitleORId> result = _dbcontext.Connection.Query<GitMaxAndMinRatinByPostTitleORId>("GitMaxAndMinRatinByPostTitleORId",p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        //Search posts by User name or by category title or by post title
        public List<SearchData1> Search(string search)
        {

            var p = new DynamicParameters();
            p.Add("@search", search, dbType: DbType.String, direction: ParameterDirection.Input);
           
          IEnumerable<SearchData1> result = _dbcontext.Connection.Query<SearchData1>("Search", p, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }
        //Git The Count of Positive Rating (4-5) Post By its Id or Title 
        public List<GitCountOfPostiveReviewsByIdOrTitle> GitCountOfPostiveReviewsByIdOrTitle(string search)
        {
            var p = new DynamicParameters();
            p.Add("@search", search, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<GitCountOfPostiveReviewsByIdOrTitle> result = _dbcontext.Connection.Query<GitCountOfPostiveReviewsByIdOrTitle>("GitCountOfPostiveReviewsByIdOrTitle", p, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        //procedure to get the  post has maximum number of rating by useres*/
        public List<MaxPostHasReview> MaxPostHasReview()
        {
            IEnumerable<MaxPostHasReview> result = _dbcontext.Connection.Query<MaxPostHasReview>("select top 1* from  ( SELECT MAX(y.num) As MaxPostHasReviews, y.Bloger, y.PostTitle FROM(SELECT  P.Title as PostTitle, U.Fname As Bloger, Count(R.Stars) As num FROM Post As P INNER JOIN PostReview as R on P.Id = R.Postid inner join Users as U on U.Id = P.userid  Group by  P.Title, U.Fname )y  INNER JOIN PostReview as R on R.Stars = y.num INNER JOIN Post p on P.Id = R.Postid Group by y.Bloger, y.PostTitle) x order by x.MaxPostHasReviews desc", commandType: CommandType.Text);
            return result.ToList();

        }


        //Search posts by User name or by category title or by post title ((For Clients))

        public List<SearchPostsByClients> SearchAboutPostsByUserNameOrPostTitleOrCategoryTitle(string search)
        {
            var p = new DynamicParameters();
            p.Add("@search", search, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<SearchPostsByClients> result = _dbcontext.Connection.Query<SearchPostsByClients>("SearchAboutPostsByUserNameOrPostTitleOrCategoryTitle", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        //Client Can Display Posts Details 
        public List<DisplayPostDetails> UserDisplayPostDetails(int id)
        {
            var p = new DynamicParameters();
            p.Add("@PostId", id, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<DisplayPostDetails> result = _dbcontext.Connection.Query<DisplayPostDetails>("UserDisplayPostDetails", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        //Posts User Liked
        public List<PostUserLiked> GetPostUserliked(int id)
        {
            var p = new DynamicParameters();

            p.Add("@UserId", id, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<PostUserLiked> result = _dbcontext.Connection.Query<PostUserLiked>("GetPostUserliked", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        // Display All Posts image and category and user( name and image ) JOIN
        public List<DisplayAllPosts> DisplayAllPosts()
        {
            IEnumerable<DisplayAllPosts> result = _dbcontext.Connection.Query<DisplayAllPosts>("select   P.Id ,U.Fname , U.Lastname , U.Image  ,P.Image As Images,P.Title,P.PostContant,P.CreateAt,C.title as CategoryTitle,C.metaTitle From Post P Inner Join Users U On P.userid = U.Id Inner Join Category C On P.CategoreId = C.Id Order By P.Id desc", commandType: CommandType.Text);

            return result.ToList();
        }

        public List<GetLastesPost> GetLastesPost()
        {
            IEnumerable<GetLastesPost> result = _dbcontext.Connection.Query<GetLastesPost>("GetLastesPost", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }


        // Display each post with each comments by Id
        public List<DisplayPostComments> DisplayPostComments(int id)
        {
            var p = new DynamicParameters();

            p.Add("@PostId", id, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<DisplayPostComments> result = _dbcontext.Connection.Query<DisplayPostComments>("DisplayPostComments", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<DisplayAllPostUser> DisplayAllPostUser(int id)
        {
            var p = new DynamicParameters();

            p.Add("@userId", id, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<DisplayAllPostUser> result = _dbcontext.Connection.Query<DisplayAllPostUser>("DisplayAllPostsUser", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }



    }
}
