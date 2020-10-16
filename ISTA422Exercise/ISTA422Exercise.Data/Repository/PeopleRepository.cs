using System.Linq;
using ISTA422Exercise.Data.Data;
using ISTA422Exercise.Data.Data.Models;
using ISTA422Exercise.Data.Repository.IRepository;

namespace ISTA422Exercise.Data.Repository
{
    public class PeopleRepository : Repository<Person>, IPeopleRepository
    {
        private readonly ApplicationDbContext _db;
        public PeopleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Person people)
        {
            var objFromDb = _db.People.FirstOrDefault(s => s.Id == people.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = people.Name;
                objFromDb.Age = people.Age;
                objFromDb.Hobby = people.Hobby;
                objFromDb.Sex = objFromDb.Sex;
            }
        }
    }
}
