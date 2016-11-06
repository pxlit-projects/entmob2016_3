package be.pxl.vegisens.repository;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import be.pxl.vegisens.domain.GrowableItem;

@Repository
public interface GrowableItemRepository extends CrudRepository<GrowableItem, Integer>
{

}
