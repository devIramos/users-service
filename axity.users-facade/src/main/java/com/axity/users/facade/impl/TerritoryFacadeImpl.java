package com.axity.users.facade.impl;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.axity.users.commons.dto.TerritoryDto;
import com.axity.users.commons.request.PaginatedRequestDto;
import com.axity.users.commons.response.GenericResponseDto;
import com.axity.users.commons.response.PaginatedResponseDto;
import com.axity.users.facade.TerritoryFacade;
import com.axity.users.service.TerritoryService;

/**
 * Class TerritoryFacadeImpl
 * @author alejandro.menchaca@axity.com
 */
@Service
@Transactional
public class TerritoryFacadeImpl implements TerritoryFacade
{
  @Autowired
  private TerritoryService territoryService;
  /**
   * {@inheritDoc}
   */
  @Override
  public PaginatedResponseDto<TerritoryDto> findTerritorys( PaginatedRequestDto request )
  {
    return this.territoryService.findTerritorys( request );
  }

  /**
   * {@inheritDoc}
   */
  @Override
  public GenericResponseDto<TerritoryDto> find( Integer id )
  {
    return this.territoryService.find( id );
  }

  /**
   * {@inheritDoc}
   */
  @Override
  public GenericResponseDto<TerritoryDto> create( TerritoryDto dto )
  {
    return this.territoryService.create( dto );
  }

  /**
   * {@inheritDoc}
   */
  @Override
  public GenericResponseDto<Boolean> update( TerritoryDto dto )
  {
    return this.territoryService.update( dto );
  }

  /**
   * {@inheritDoc}
   */
  @Override
  public GenericResponseDto<Boolean> delete( Integer id )
  {
    return this.territoryService.delete( id );
  }
}
