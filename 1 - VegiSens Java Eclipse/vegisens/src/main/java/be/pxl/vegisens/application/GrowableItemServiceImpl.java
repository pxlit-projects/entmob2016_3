package be.pxl.vegisens.application;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import javax.persistence.NamedQuery;

@Service
@Transactional
public class GrowableItemServiceImpl implements IGrowableItemService
{
	@Autowired
	private GrowableItemRepository growableItemRepository;
	
	@Autowired
	private GrowableItemEntityRepository entityRepository;
	
	public List<GrowableItem> getAllGrowableItems() 
	{
		return (List<GrowableItem>) growableItemRepository.findAll();
	}

	public void addGrowableItem(GrowableItemEntity growableItemToAdd) 
	{
		entityRepository.save(growableItemToAdd);			
	}

	public GrowableItem getGrowableItemById(int id) {
		return growableItemRepository.findOne(id);
	}
}

