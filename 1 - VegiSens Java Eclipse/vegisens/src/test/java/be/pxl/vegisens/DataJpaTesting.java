package be.pxl.vegisens;

import org.hamcrest.CoreMatchers;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.AutoConfigureTestDatabase;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import org.springframework.boot.test.autoconfigure.orm.jpa.TestEntityManager;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.ActiveProfiles;
import org.springframework.test.context.TestPropertySource;
import org.springframework.test.context.junit4.SpringRunner;

import be.pxl.vegisens.controller.entity.GrowableItemEntity;
import be.pxl.vegisens.domain.GrowableItem;
import be.pxl.vegisens.domain.Humidity;
import be.pxl.vegisens.domain.SensorType;
import be.pxl.vegisens.domain.Temperature;
import be.pxl.vegisens.repository.GrowableItemEntityRepository;
import be.pxl.vegisens.repository.GrowableItemRepository;
import be.pxl.vegisens.repository.SensorTypeRepository;

import static org.junit.Assert.*;
import static org.hamcrest.CoreMatchers.*;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import javax.transaction.Transactional;


/**
 * Created by aless on 28/10/2016.
 */

//Testing the repository layer

@RunWith(SpringRunner.class) //Indicates that the class should use Spring's JUnit facilities
@SpringBootTest(classes = VegiSensApplication.class)
@DataJpaTest
// http://docs.spring.io/spring-boot/docs/current/reference/html/boot-features-testing.html
//Determines what type of existing DataSource beans can be replaced.
//NONE: Don't replace the application default DataSource. -> VERVANG DE DATABASE CONNECTIE NIET MET EEN EMBEDDED CONNECTIE
@AutoConfigureTestDatabase(replace= AutoConfigureTestDatabase.Replace.NONE)
public class DataJpaTesting
{

    @Autowired
    private TestEntityManager entityManager;

    @Autowired
    private GrowableItemRepository growableItemRepository;

    @Autowired
    private SensorTypeRepository sensorTypeRepository;

    //Merge: If your entity is new, it's the same as a persist(). But if your entity already exists, it will update it.
    @Test
    public void testGetSensorTypeById_AfterPersistingNewSensorType()
    {
        SensorType sensorTypeToPersist = new SensorType();
        
        sensorTypeToPersist.setSensortypeId(1);
        sensorTypeToPersist.setSensortypeUnit("%");
        sensorTypeToPersist.setSensorName("Temp Sensor");
        
        entityManager.merge(sensorTypeToPersist);
        
        SensorType foundSensorTypeById = sensorTypeRepository.findOne(1);

        assertEquals(1, foundSensorTypeById.getSensortypeId());		
    }
    
    @Test
    public void testGetAllSensorTypes_AfterPersistingAllSensorTypes()
    {    	
        SensorType sensorType1ToPersist = new SensorType();
        
        sensorType1ToPersist.setSensortypeId(1);
        sensorType1ToPersist.setSensorName("Temp sensor");
        sensorType1ToPersist.setSensortypeUnit("°C");
        
        SensorType sensorType2ToPersist = new SensorType();
        
        sensorType2ToPersist.setSensortypeId(2);
        sensorType2ToPersist.setSensorName("Hum sensor");
        sensorType2ToPersist.setSensortypeUnit("%");
        
        List<SensorType> sensorTypeList = Arrays.asList(sensorType1ToPersist,sensorType2ToPersist);

        entityManager.merge(sensorType1ToPersist);
        entityManager.merge(sensorType2ToPersist);
     
        List<SensorType> foundSensorTypeList = (ArrayList<SensorType>) sensorTypeRepository.findAll();

        assertThat(foundSensorTypeList, is(sensorTypeList));
       
    }
    
    @Test
    public void testUpdateGrowableItem_AfterPersisterNewGrowableItem()
    {    	
    	GrowableItem growableItemToUpdate = new GrowableItem();
    	
    	growableItemToUpdate.setGrowableItemId(1);
    	growableItemToUpdate.setName("This is a name");
    	growableItemToUpdate.setHumidity(new Humidity());
    	growableItemToUpdate.setTemperature(new Temperature());

    	entityManager.merge(growableItemToUpdate);
    	
    	growableItemToUpdate.setName("New Name");
    	
    	growableItemRepository.save(growableItemToUpdate);
    	
    	GrowableItem foundItem = growableItemRepository.findOne(1);
    	
    	assertEquals(growableItemToUpdate.getName(), foundItem.getName());	
    }
    
    @Test
    public void testGetGrowableItemById_AfterPersistingNewGrowableItem()
    {    	
        GrowableItem growableItemToSave = new GrowableItem();

        growableItemToSave.setGrowableItemId(1);   
        growableItemToSave.setName("Testname");
        growableItemToSave.setHumidity( new Humidity());  
        growableItemToSave.setTemperature(new Temperature());  
                
        entityManager.merge(growableItemToSave);
        
        GrowableItem foundGrowableItemEntityToSave = growableItemRepository.findOne(1);

        assertEquals(1, foundGrowableItemEntityToSave.getGrowableItemId());	       
    }
    
    @Test
    public void testSaveGrowableItem()
    {    	
    	GrowableItem growableItemToSave = new GrowableItem();
    	
    	growableItemToSave.setGrowableItemId(1);
    	growableItemToSave.setName("TestNameGrowableItem");
    	growableItemToSave.setHumidity(new Humidity());
    	growableItemToSave.setTemperature(new Temperature());

    	growableItemRepository.save(growableItemToSave);
    	
    	GrowableItem foundItem = growableItemRepository.findOne(1);
    	
    	assertEquals(growableItemToSave, foundItem);
    }
}