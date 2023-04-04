package com.axity.users.facade.impl;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.axity.users.commons.dto.UserDto;
import com.axity.users.commons.request.PaginatedRequestDto;
import com.axity.users.commons.response.GenericResponseDto;
import com.axity.users.commons.response.PaginatedResponseDto;
import com.axity.users.facade.UserFacade;
import com.axity.users.service.UserService;

/**
 * Class UserFacadeImpl
 * @author alejandro.menchaca@axity.com
 */
@Service
@Transactional
public class UserFacadeImpl implements UserFacade
{
  @Autowired
  private UserService userService;
  /**
   * {@inheritDoc}
   */
  @Override
  public PaginatedResponseDto<UserDto> findUsers( PaginatedRequestDto request )
  {
    return this.userService.findUsers( request );
  }

  /**
   * {@inheritDoc}
   */
  @Override
  public GenericResponseDto<UserDto> find( Integer id )
  {
    return this.userService.find( id );
  }

  /**
   * {@inheritDoc}
   */
  @Override
  public GenericResponseDto<UserDto> create( UserDto dto )
  {
    return this.userService.create( dto );
  }

  /**
   * {@inheritDoc}
   */
  @Override
  public GenericResponseDto<Boolean> update( UserDto dto )
  {
    return this.userService.update( dto );
  }

  /**
   * {@inheritDoc}
   */
  @Override
  public GenericResponseDto<Boolean> delete( Integer id )
  {
    return this.userService.delete( id );
  }
}
