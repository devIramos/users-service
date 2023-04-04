package com.axity.users.persistence;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.axity.users.model.CountryDO;

/**
 * Persistence interface of  de {@link com.axity.users.model.CountryDO}
 * 
 * @author alejandro.menchaca@axity.com
 */
@Repository
public interface CountryPersistence extends JpaRepository<CountryDO, Integer>
{
  // Agregar consultas personalizadas
}
