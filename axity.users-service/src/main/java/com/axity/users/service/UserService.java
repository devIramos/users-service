package com.axity.users.service;

import java.util.List;

import com.axity.users.commons.dto.UserDto;
import com.axity.users.commons.request.PaginatedRequestDto;
import com.axity.users.commons.response.GenericResponseDto;
import com.axity.users.commons.response.PaginatedResponseDto;

/**
 * Interface UserService
 * 
 * @author alejandro.menchaca@axity.com
 */
public interface UserService
{

  /**
   * Method to get Users
   * 
   * @param request
   * @return
   */
  PaginatedResponseDto<UserDto> findUsers( PaginatedRequestDto request );

  /**
   * Method to get User by id
   * 
   * @param id
   * @return
   */
  GenericResponseDto<UserDto> find( Integer id );

  /**
   * Method to create a User
   * 
   * @param dto
   * @return
   */
  GenericResponseDto<UserDto> create( UserDto dto );

  /**
   * Method to update a User
   * 
   * @param dto
   * @return
   */
  GenericResponseDto<Boolean> update( UserDto dto );

  /**
   * Method to delete a User
   * 
   * @param id
   * @return
   */
  GenericResponseDto<Boolean> delete( Integer id );
}
