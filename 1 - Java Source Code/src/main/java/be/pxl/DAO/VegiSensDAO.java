package be.pxl.DAO;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.EntityTransaction;
import javax.persistence.Persistence;

import be.pxl.models.Growable_ItemBean;

public class VegiSensDAO implements IServiceDAO
{
	private static EntityManagerFactory entityFactory = Persistence.createEntityManagerFactory("VegiSensPersistence");
	
	public Growable_ItemBean getGrowableItemBeanData(Growable_ItemBean growable_item)
	{
		EntityManager entityManager = entityFactory.createEntityManager();
		EntityTransaction entityTransaction = entityManager.getTransaction();
		
		entityTransaction.begin();
		
		Growable_ItemBean receivedGrowableItem = entityManager.find(Growable_ItemBean.class, growable_item.getId());
		
		entityTransaction.commit();
		
		entityManager.close();
		
		return receivedGrowableItem;
	}
}
