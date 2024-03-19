using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entity;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private IMediator _mediator;
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();
            if (productsQuery == null)
                throw new ApplicationException($"Entity could not be found");
            var result = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productQuery = new GetProductByIdQuery(id.Value);
            if (productQuery == null)
                throw new ApplicationException($"Entity could not be found");
            var result = await _mediator.Send(productQuery);
            return _mapper.Map<ProductDTO>(result);
        }

        public async Task<ProductDTO> GetProductCategory(int? id)
        {
            var productQuery = new GetProductByIdQuery(id.Value);
            if (productQuery == null)
                throw new ApplicationException($"Entity could not be found");
            var result = await _mediator.Send(productQuery);
            return _mapper.Map<ProductDTO>(result);
        }

        public async Task Add(ProductDTO productDto)
        {
            var ProductCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);
            await _mediator.Send(ProductCreateCommand);
        }

        public async Task Update(ProductDTO productDto)
        {
            var ProductUpdateCommand = _mapper.Map<ProductCreateCommand>(productDto);
            await _mediator.Send(ProductUpdateCommand);
        }
        public async Task Delete(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);
            if (productRemoveCommand == null)
                throw new ApplicationException($"Entity could not be found");
            await _mediator.Send(productRemoveCommand);
        }
    }
}
