package com.axity.users.persistence;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.axity.users.model.RoleDO;

/**
 * Persistence interface of  de {@link com.axity.users.model.RoleDO}
 * 
 * @author alejandro.menchaca@axity.com
 */
@Repository
public interface RolePersistence extends JpaRepository<RoleDO, Integer>
{
  // Agregar consultas personalizadas
}
