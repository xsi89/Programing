-- Auto Chamfer
-- Version 1.6
-- Created On: 11/07/2013
-- tested using Max 9,2009
-- by Lantlant

rollout DialogBaka "Auto Chamfer"
(

spinner kurucok "chamfer size" range:[0,10000,3.5]
spinner labancok "threshold angle" range:[0,180,40]				
button hernyotalp "CHAMFER" width:190 height:40
progressbar reszfeladat pos:[2,92] height:12 width:194  color: red
progressbar teljesfolyamat pos:[2,106] height:20 width:194 color: blue

on 	hernyotalp pressed do
(
  manko = 1
  if selection.count == 0 then
    (
      messagebox "select geometry / geometries"
	)
  else
    ( 
      for n = 1 to selection.count do
	           (
	             if superclassof selection[n] != GeometryClass then
                    ( 
					  manko = 17
					)
			     else ()  	  
	           )
      if manko == 17 then messagebox "Not only is the geometry between the selected objects" 
      if manko == 1 then
      (
---------------maga az elletoro---------  
    disablesceneredraw()
    undo "Auto Chamfer" on 
      (
	    kisszelektaltak = selection as array
		max select none
	    for i = 1 to kisszelektaltak.count do
		  (
      
          teljesfolyamat.value = 100.*(i-1)/kisszelektaltak.count
obj = kisszelektaltak[i]
convertTo obj TriMeshGeometry

select obj
 
nyitottelek = meshop.getOpenEdges obj
reszfeladat.value = 100.*(0.1)
--
EredetiElek=#()
for face = 1 to obj.numfaces do
for edge = 1 to 3 do 
if (getedgevis obj face edge) do 
append EredetiElek (((face-1)*3)+edge) 
---
reszfeladat.value = 100.*(0.3)
setEdgeSelection obj #{1..(obj.edges.count)}
reszfeladat.value = 100.*(0.5)          
meshop.autoEdge obj #{1..(obj.edges.count)} labancok.value
--
LetorendoElek=#()
for face = 1 to obj.numfaces do
for edge = 1 to 3 do 
if (getedgevis obj face edge) do 
append LetorendoElek (((face-1)*3)+edge)
reszfeladat.value = 100.*(0.7) 
--
meshOp.autoEdge obj EredetiElek 0     --megis meg lehet csinalni... 
          
setedgeselection obj LetorendoElek
reszfeladat.value = 100.*1  
deselect obj.edges[nyitottelek]     									
--

meshop.chamferEdges obj LetorendoElek kurucok.value

reszfeladat.value = 0              
          )
	    select kisszelektaltak	  
      )
	 teljesfolyamat.value = 0 
	 enablesceneredraw()
     redrawviews()
--------
	  )  
    			   
	)  
)

)
createdialog DialogBaka 198 130 