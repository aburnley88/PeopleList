using ISTA422Exercise.Data.Data.Models;

namespace ISTA422Exercise.Data.Repository.IRepository
{
    public interface IPeopleRepository : IRepository<Person>
    {
        void Update(Person person);
    }
}
