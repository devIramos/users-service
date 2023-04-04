package com.axity.users.persistence;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.axity.users.model.UserDO;

/**
 * Persistence interface of  de {@link com.axity.users.model.UserDO}
 * 
 * @author alejandro.menchaca@axity.com
 */
@Repository
public interface UserPersistence extends JpaRepository<UserDO, Integer>
{
  // Agregar consultas personalizadas
}
