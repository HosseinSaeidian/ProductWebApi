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


        [HttpGet("GiveAllProduct")]
        public async Task<ActionResult<IEnumerable<ShowProductDto>>> GetProductAsync()
        {
            var product = await _repository.GetValuesAll();
            var showProduct = _mapper.Map<IEnumerable<ShowProductDto>>(product);
            return Ok(showProduct);
        }


        [HttpGet("filter/price/minprice/{minprice}")]
        public async Task<ActionResult<IEnumerable<ShowProductDto>>> GetFillterMinPriceAsync([FromRoute] int minprice)
        {
            try
            {
                var product = await _repository.GetWithFillter(a => a.Price >= minprice);
                var showProduct = _mapper.Map<IEnumerable<ShowProductDto>>(product);
                return Ok(showProduct);

            }
            catch (System.Exception)
            {

                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpGet("filter/price/maxprice/{maxprice}")]
        public async Task<ActionResult<IEnumerable<ShowProductDto>>> GetFillterMaxPriceAsync([FromRoute] int maxprice)
        {

            try
            {
                var product = await _repository.GetWithFillter(a => a.Price <= maxprice);

                var showProduct = _mapper.Map<IEnumerable<ShowProductDto>>(product);
                return Ok(showProduct);


            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }

        }


        [HttpGet("filterDynamic")]
        public async Task<ActionResult<IEnumerable<ShowProductDto>>> GetFillterAsync([FromQuery] string? filter)
        {
            var product = await _repository.GetWithFillterExpressionTree(filter);
            var showProduct = _mapper.Map<IEnumerable<ShowProductDto>>(product);
            return Ok(showProduct);
        }


        [HttpGet("FillterWithPagingOne")]
        public async Task<ActionResult<IEnumerable<ShowProductDto>>> GetPaginOneAsync([FromQuery] string? filtern, [FromQuery] int pageSize, [FromQuery] int pageIndex)
        {
            var product = await _repository.GetWithFillterAndPaging(filtern, pageSize, pageIndex);
            var showProduct = _mapper.Map<IEnumerable<ShowProductDto>>(product);
            return Ok(showProduct);
        }


        [HttpGet("FillterWithPagingTwo")]
        public async Task<ActionResult<IEnumerable<ShowProductDto>>> GetPagingTwoAsync([FromQuery] string? filter, [FromQuery] int? pageSize = 2, [FromQuery] int? pageIndex = 1)
        {
            var product = await _repository.GetWithFillterAndPaging(filter , pageSize.Value, pageIndex.Value);
            var showProduct = _mapper.Map<IEnumerable<ShowProductDto>>(product);
            return Ok(showProduct);
        }

         [HttpGet("FillterWithPagingThree")]
        public async Task<ActionResult<IEnumerable<ShowProductDto>>> GetPagingThreeAsync([FromQuery] ProductFillterDto fillter)
        {
            var product = await _repository.GetWithFillterAndPaging(fillter.Fillter , fillter.PageSize.Value , fillter.PageIndex.Value);
            var showProduct = _mapper.Map<IEnumerable<ShowProductDto>>(product);
            return Ok(showProduct);
        }


         [HttpGet("FillterWithPaging")]
        public async Task<ActionResult<IEnumerable<ShowProductDto>>> GetPagingFinnaly([FromQuery] ProductFillterDto fillter)
        {
            var paging = _mapper.Map<PagingParam>(fillter);

            var product = await _repository.FillterAsync(fillter.Fillter , paging);
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
