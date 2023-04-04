package com.axity.users.service;

import java.util.List;

import com.axity.users.commons.dto.RoleDto;
import com.axity.users.commons.request.PaginatedRequestDto;
import com.axity.users.commons.response.GenericResponseDto;
import com.axity.users.commons.response.PaginatedResponseDto;

/**
 * Interface RoleService
 * 
 * @author alejandro.menchaca@axity.com
 */
public interface RoleService
{

  /**
   * Method to get Roles
   * 
   * @param request
   * @return
   */
  PaginatedResponseDto<RoleDto> findRoles( PaginatedRequestDto request );

  /**
   * Method to get Role by id
   * 
   * @param id
   * @return
   */
  GenericResponseDto<RoleDto> find( Integer id );

  /**
   * Method to create a Role
   * 
   * @param dto
   * @return
   */
  GenericResponseDto<RoleDto> create( RoleDto dto );

  /**
   * Method to update a Role
   * 
   * @param dto
   * @return
   */
  GenericResponseDto<Boolean> update( RoleDto dto );

  /**
   * Method to delete a Role
   * 
   * @param id
   * @return
   */
  GenericResponseDto<Boolean> delete( Integer id );
}
