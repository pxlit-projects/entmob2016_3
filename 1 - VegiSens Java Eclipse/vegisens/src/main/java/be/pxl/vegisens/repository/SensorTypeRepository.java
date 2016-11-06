package be.pxl.vegisens.repository;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import be.pxl.vegisens.domain.SensorType;

@Repository
public interface SensorTypeRepository extends CrudRepository<SensorType, Integer>
{

}
