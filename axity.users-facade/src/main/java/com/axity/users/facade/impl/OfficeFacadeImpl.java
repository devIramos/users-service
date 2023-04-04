package com.axity.users.facade.impl;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.axity.users.commons.dto.OfficeDto;
import com.axity.users.commons.request.PaginatedRequestDto;
import com.axity.users.commons.response.GenericResponseDto;
import com.axity.users.commons.response.PaginatedResponseDto;
import com.axity.users.facade.OfficeFacade;
import com.axity.users.service.OfficeService;

/**
 * Class OfficeFacadeImpl
 * @author alejandro.menchaca@axity.com
 */
@Service
@Transactional
public class OfficeFacadeImpl implements OfficeFacade
{
  @Autowired
  private OfficeService officeService;
  /**
   * {@inheritDoc}
   */
  @Override
  public PaginatedResponseDto<OfficeDto> findOffices( PaginatedRequestDto request )
  {
    return this.officeService.findOffices( request );
  }

  /**
   * {@inheritDoc}
   */
  @Override
  public GenericResponseDto<OfficeDto> find( Integer id )
  {
    return this.officeService.find( id );
  }

  /**
   * {@inheritDoc}
   */
  @Override
  public GenericResponseDto<OfficeDto> create( OfficeDto dto )
  {
    return this.officeService.create( dto );
  }

  /**
   * {@inheritDoc}
   */
  @Override
  public GenericResponseDto<Boolean> update( OfficeDto dto )
  {
    return this.officeService.update( dto );
  }

  /**
   * {@inheritDoc}
   */
  @Override
  public GenericResponseDto<Boolean> delete( Integer id )
  {
    return this.officeService.delete( id );
  }
}
