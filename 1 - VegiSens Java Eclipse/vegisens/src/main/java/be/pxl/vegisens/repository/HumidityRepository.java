package be.pxl.vegisens.repository;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import be.pxl.vegisens.domain.Humidity;

@Repository
public interface HumidityRepository extends CrudRepository<Humidity, Integer> {


}
