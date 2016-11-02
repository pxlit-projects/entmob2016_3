package be.pxl.vegisens.application;

import java.util.List;

public interface IGrowableItemService {

	List<GrowableItem> getAllGrowableItems();
	void addGrowableItem(GrowableItemEntity growableItemToAdd);
	GrowableItem getGrowableItemById(int id);
}
