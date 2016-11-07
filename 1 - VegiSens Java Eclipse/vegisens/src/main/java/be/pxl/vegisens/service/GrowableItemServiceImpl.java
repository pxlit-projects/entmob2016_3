package be.pxl.vegisens.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import be.pxl.vegisens.controller.entity.GrowableItemEntity;
import be.pxl.vegisens.domain.GrowableItem;
import be.pxl.vegisens.repository.GrowableItemEntityRepository;
import be.pxl.vegisens.repository.GrowableItemRepository;
import be.pxl.vegisens.service.interfaces.IGrowableItemService;


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

	@Override
	public GrowableItem getGrowableItemById(int id) 
	{
		return growableItemRepository.findOne(id);
	}
}

