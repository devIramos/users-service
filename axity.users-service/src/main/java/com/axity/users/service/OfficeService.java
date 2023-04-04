package com.axity.users.service;

import java.util.List;

import com.axity.users.commons.dto.OfficeDto;
import com.axity.users.commons.request.PaginatedRequestDto;
import com.axity.users.commons.response.GenericResponseDto;
import com.axity.users.commons.response.PaginatedResponseDto;

/**
 * Interface OfficeService
 * 
 * @author alejandro.menchaca@axity.com
 */
public interface OfficeService
{

  /**
   * Method to get Offices
   * 
   * @param request
   * @return
   */
  PaginatedResponseDto<OfficeDto> findOffices( PaginatedRequestDto request );

  /**
   * Method to get Office by id
   * 
   * @param id
   * @return
   */
  GenericResponseDto<OfficeDto> find( Integer id );

  /**
   * Method to create a Office
   * 
   * @param dto
   * @return
   */
  GenericResponseDto<OfficeDto> create( OfficeDto dto );

  /**
   * Method to update a Office
   * 
   * @param dto
   * @return
   */
  GenericResponseDto<Boolean> update( OfficeDto dto );

  /**
   * Method to delete a Office
   * 
   * @param id
   * @return
   */
  GenericResponseDto<Boolean> delete( Integer id );
}
