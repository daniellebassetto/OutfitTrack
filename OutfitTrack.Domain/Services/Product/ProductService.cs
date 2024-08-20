﻿using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;
using OutfitTrack.Domain.Interfaces.Repository;
using OutfitTrack.Domain.Interfaces.Service;

namespace OutfitTrack.Domain.Services;

public class ProductService(IUnitOfWork unitOfWork) : BaseService<IProductRepository, InputCreateProduct, InputUpdateProduct, Product, OutputProduct, InputIdentifierProduct>(unitOfWork), IProductService 
{
    public override OutputProduct? Create(InputCreateProduct inputCreate)
    {
        Product? originalProduct = _repository!.GetByIdentifier(new InputIdentifierProduct(inputCreate.Code!));

        if (originalProduct is not null)
            throw new InvalidOperationException($"Código '{inputCreate.Code}' já cadastrado na base de dados.");

        Product product = FromInputCreateToEntity(inputCreate);
        var entity = _repository.Create(product);
        _unitOfWork!.Commit();

        return FromEntityToOutput(entity ?? new Product());
    }

    public override OutputProduct? Update(long id, InputUpdateProduct inputUpdate)
    {
        Product? originalProduct = _repository!.Get(x => x.Id == id) ?? throw new KeyNotFoundException($"Não foi encontrado nenhum produto correspondente a este Id.");

        Product product = UpdateEntity(originalProduct, inputUpdate) ?? throw new Exception("Problemas para realizar atualização");
        var entity = _repository!.Update(product);
        _unitOfWork!.Commit();

        return FromEntityToOutput(entity ?? new Product());
    }

    public override bool Delete(long id)
    {
        Product? originalProduct = _repository!.Get(x => x.Id == id) ?? throw new KeyNotFoundException($"Não foi encontrado nenhum produto correspondente a este Id.");

        if (originalProduct.ListOrderItem?.Count == 0 || originalProduct.ListOrderItem is null)
            throw new InvalidOperationException($"Esse produto possui vínculo com itens de pedido");

        _repository.Delete(originalProduct);
        _unitOfWork!.Commit();

        return true;
    }
}