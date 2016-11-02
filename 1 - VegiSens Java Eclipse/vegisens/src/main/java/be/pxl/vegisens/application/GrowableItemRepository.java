package be.pxl.vegisens.application;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface GrowableItemRepository extends CrudRepository<GrowableItem, Integer>
{

}
