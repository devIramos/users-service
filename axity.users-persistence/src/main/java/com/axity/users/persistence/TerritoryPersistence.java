package com.axity.users.persistence;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.axity.users.model.TerritoryDO;

/**
 * Persistence interface of  de {@link com.axity.users.model.TerritoryDO}
 * 
 * @author alejandro.menchaca@axity.com
 */
@Repository
public interface TerritoryPersistence extends JpaRepository<TerritoryDO, Integer>
{
  // Agregar consultas personalizadas
}
