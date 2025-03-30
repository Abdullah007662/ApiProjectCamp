using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.FeatureDTO;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public FeaturesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _context.Features.ToList();
            return Ok(_mapper.Map<List<ResultFeatureDTO>>(values));
        }
        [HttpGet("GetByFeature")]
        public IActionResult GetByFeature(int id)
        {
            var values = _context.Features.Find(id);
            return Ok(_mapper.Map<GetByIdFeatureDTO>(values));
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDTO createFeatureDTO)
        {
            var values = _mapper.Map<Feature>(createFeatureDTO);
            _context.Features.Add(values);
            _context.SaveChanges();
            return Ok("Başarılı Bir Şekilde Eklendi.!");
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDTO feature)
        {
            var value = _mapper.Map<Feature>(feature);
            _context.Features.Update(value);
            _context.SaveChanges();
            return Ok("Başarılı Bir Şekilde Güncellendi.!");
        }
        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value = _context.Features.Find(id);
            _context.Features.Remove(value!);
            _context.SaveChanges();
            return Ok("Başarılı Bir Şekilde Silindi.!");
        }
    }
}
