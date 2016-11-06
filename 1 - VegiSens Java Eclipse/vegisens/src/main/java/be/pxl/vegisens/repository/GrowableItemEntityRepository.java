package be.pxl.vegisens.repository;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import be.pxl.vegisens.controller.entity.GrowableItemEntity;

@Repository
public interface GrowableItemEntityRepository extends CrudRepository<GrowableItemEntity, Integer> {


}

