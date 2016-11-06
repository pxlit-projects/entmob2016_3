package be.pxl.vegisens.repository;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import be.pxl.vegisens.domain.Temperature;

@Repository
public interface TemperatureRepository extends CrudRepository<Temperature, Integer> {


}
