using SunnyRewards.HelloWorld.Common.Models;
using System.Linq.Expressions;

namespace SunnyRewards.HelloWorld.Common.Repos.Interfaces
{
    public interface IBaseRepo<T> where T : BaseModel
    {
        /// <summary>
        /// Find db record by using expression of query.
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        Task<IList<T>> FindAsync(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Find one db record using id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<T?> FindOneAsync(int Id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<T> CreateAsync(T model);

        /// <summary>
        /// Update a particular record in DB
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<T> UpdateAsync(T model);

        /// <summary>
        /// Delete a particular record from DB, it will be a soft delete will only set
        /// ActiveInd = false
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Will get all the records for particular table/model
        /// </summary>
        /// <returns></returns>
        Task<IList<T>> FindAllAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<IList<T>> FindWithExpAsync(Expression<Func<T, bool>> expression);
    }
}
