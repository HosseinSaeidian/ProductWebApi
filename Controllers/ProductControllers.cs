using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SessionNine.Application.Models;
using SessionNine.Application.Models.Product;
using SessionNine.Domains.Entity;
using SessionNine.Infrastructure.Data.Core;
using System.Linq.Dynamic.Core;
using ProductWebApi.Application.Models.Product;
using ProductWebApi.Infrastructure.Data.Services.Paging;

namespace SessionNine.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductControllers : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductControllers(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        #region Methods


        [HttpPost("AddProduct")]
        public async Task<ActionResult<IEnumerable<ShowProductDto>>> AddProductAsync(
            [FromBody] CreateProductOne createPro
        )
        {
            var product = _mapper.Map<Product>(createPro);
            await _repository.AddAsync(product);
            var showProduct = _mapper.Map<ShowProductDto>(product);
            return Ok(showProduct);
        }


        [HttpGet("FillterWithPaging")]
        public async Task<ActionResult<IEnumerable<ShowProductDto>>> GetPagingFinnaly([FromQuery] ProductFillterDto dto)
        {
            var paging = _mapper.Map<PagingParam>(dto);

            var product = await _repository.FillterAsync(dto.Fillter, dto.Sort , paging);
            var showProduct = _mapper.Map<IEnumerable<ShowProductDto>>(product);
            return Ok(showProduct);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ShowProductDto>>> GetProductWithIdAsync([FromRoute] int id)
        {
            var product = await _repository.GetValueWithId(id);

            if (product == null)
            {
                return NotFound($"Invalid id : {id}");
            }
            else
            {
                var showProduct = _mapper.Map<ShowProductDto>(product);
                return Ok(showProduct);
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<ShowProductDto>>> UpdateEntityAsync(int id, [FromBody] EditProductModel updateProduct)
        {
            try
            {
                var productMapped = _mapper.Map<Product>(updateProduct);
                productMapped.Id = id;
                await _repository.UpdateAsync(productMapped);
                var showProduct = _mapper.Map<ShowProductDto>(productMapped);
                return Ok(showProduct);

            }
            catch (System.Exception)
            {
                return BadRequest("Your Id is invalid or another reson");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductAsync(int id)
        {
            try
            {
                #region Code 

                var product = await _repository.GetValueWithId(id);

                if (product == null)
                {
                    return BadRequest("your Id is inValid");
                }
                else
                {

                    await _repository.DeleteAsync(product);
                    return Ok("Your product deleted succesfully");

                }

                #endregion

            }
            catch (System.Exception)
            {
                return NotFound("Server can not handel Error , try later");
            }

        }

        #endregion
    }
}
