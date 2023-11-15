using Microsoft.Extensions.Logging;
using NHibernate;
using NHibernate.Linq;
using SunnyRewards.HelloWorld.Common.Models;
using SunnyRewards.HelloWorld.Common.Repos.Interfaces;
using System.Linq.Expressions;

namespace SunnyRewards.HelloWorld.Common.Repos
{
    public class BaseRepo<T> : IBaseRepo<T> where T : BaseModel
    {

        /// <summary>
        /// This will be injected in .net core dependencies and will automically auto wired here.
        /// </summary>
        private readonly ISession _session;
        private readonly ILogger<BaseRepo<T>> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public BaseRepo(ISession session, ILogger<BaseRepo<T>> logger)
        {
            _session = session;
            _logger = logger;
        }

        /// <summary>
        /// Create/persist a record in db
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>

        public async Task<T> CreateAsync(T model)
        {
            using var transaction = _session.BeginTransaction();
            try
            {
                _logger.LogInformation($"BaseRepo: CreateAsync Enter");
                if (model == null)
                    throw new ArgumentNullException(nameof(T));

                await _session.SaveAsync(model);
                _session?.FlushAsync();
                await transaction.CommitAsync();
                return model;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                _logger.LogError(ex, "BaseRepo CreateAsync Error :");
                throw;
            }
            finally
            {

                _logger.LogInformation($"BaseRepo: CreateAsync Exit");
            }
        }


        /// <summary>
        /// Delete a particular record from DB, it will be a soft delete will only set
        /// ActiveInd = false
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task DeleteAsync(int id)
        {
            try
            {
                _logger.LogInformation($"BaseRepo: DeleteAsync id={id}");
                if (id <= 0)
                    throw new ArgumentNullException("Record Id must be specified");

                var model = await FindOneAsync(id);
                if (model != null)
                {
                    await UpdateAsync(model);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BaseRepo DeleteAsync Error :");
                throw;
            }
            finally
            {
                _logger.LogInformation($"BaseRepo: DeleteAsync Exit");
            }
        }

        /// <summary>
        /// Will get all the records for particular table/model
        /// </summary>
        /// <returns></returns>
        public async Task<IList<T>> FindAllAsync()
        {
            try
            {
                _logger.LogInformation($"BaseRepo: FindAllAsync Enter");
                return await _session.Query<T>().ToListAsync<T>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BaseRepo FindAllAsync Error :");
                throw;
            }
            finally
            {
                _logger.LogInformation($"BaseRepo: FindAllAsync Exit");
            }
        }

        /// <summary>
        /// Find db record by using expression of query.
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public async Task<IList<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                _logger.LogInformation($"BaseRepo: FindAsync Enter");

                return await _session.Query<T>().Where(expression).ToListAsync<T>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BaseRepo FindAsync Error :");
                throw;
            }
            finally
            {
                _logger.LogInformation($"BaseRepo: FindAsync Exit");
            }

        }

        /// <summary>
        /// Find db record by using expression of query.
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public async Task<IList<T>> FindWithExpAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                _logger.LogInformation($"BaseRepo: FindAsync Enter");

                return await _session.Query<T>().Where(expression).ToListAsync<T>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BaseRepo FindAsync Error :");
                throw;
            }
            finally
            {
                _logger.LogInformation($"BaseRepo: FindAsync Exit");
            }

        }


        /// <summary>
        /// Get one record from DB using primary key. it will always look for active recods unless 
        /// you want inactive then switch of active parameter
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<T?> FindOneAsync(int id)
        {
            try
            {
                _logger.LogInformation($"BaseRepo: FindOneAsync Enter ");
                var model = await _session.GetAsync<T>(id);

                if (model != null)
                    return model;

                return default;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BaseRepo FindOneAsync Error :");
                throw;
            }
            finally
            {
                _logger.LogInformation($"BaseRepo: FindOneAsync Exit");
            }

        }

        /// <summary>
        /// Will update model/recors in DB
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<T> UpdateAsync(T model)
        {
            using var transaction = _session.BeginTransaction();
            try
            {
                _logger.LogInformation($"BaseRepo: UpdateAsync Enter ");
                if (model == null || model.Id <= 0)
                    throw new ArgumentNullException(nameof(T));


                await _session.UpdateAsync(model);
                await transaction.CommitAsync();
                return model;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                _logger.LogError(ex, "BaseRepo UpdateAsync Error :");
                throw;
            }
            finally
            {

                _logger.LogInformation($"BaseRepo: UpdateAsync Exit");
            }
        }
    }
}
