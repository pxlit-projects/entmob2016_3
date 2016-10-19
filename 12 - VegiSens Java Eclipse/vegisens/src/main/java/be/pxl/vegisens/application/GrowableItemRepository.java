package be.pxl.vegisens.application;

import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface GrowableItemRepository extends CrudRepository<GrowableItem, Integer> {


}
