using AutoMapper;
using Hk_Business.Repository.IRepository;
using Hk_DataAccess;
using Hk_DataAccess.Data;
using Hk_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hk_Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<CategoryDTO> Create(CategoryDTO objDTO)
        {
            //Category category = new Category()
            //{
            //    Name = objDTO.Name,
            //    Id = objDTO.Id,
            //    CreatedDate = DateTime.Now
            //};

            var obj = _mapper.Map<CategoryDTO, Category>(objDTO);       // AutoMapper 사용시에 간단히 이렇게 가능

            var addedObj = _db.Categories.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<Category, CategoryDTO>(addedObj.Entity); // AutoMapper 사용시에 간단히 이렇게 가능
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (obj != null)
            {
                _db.Categories.Remove(obj);
                await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<CategoryDTO> Get(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Category, CategoryDTO>(obj);
            }
            return new CategoryDTO();
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
        }

        public async Task<CategoryDTO> Update(CategoryDTO objDTO)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(c => c.Id == objDTO.Id);
            if (obj != null)
            {
                obj.Name = objDTO.Name; 
                _db.Categories.Update(obj);
                await _db.SaveChangesAsync();
                return _mapper.Map<Category, CategoryDTO>(obj);
            }
            return objDTO;
        }
    }
}
