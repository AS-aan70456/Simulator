# Simulator

Life_simulator is a genetic algorithm that simulates evolution and natural selection in action.
<div>application was written in sfml</div>
<p></p>

![4324Снимок](https://user-images.githubusercontent.com/107953303/235321821-5ae57b89-7d73-42c3-a1ad-5eb2f3a9953b.PNG)

The genetic algorithm works as follows:
- at the beginning, an initial population of possible solutions is created,
- then a selection of the best solutions is made,
- a check is made, if the result is not achieved,
- then based on the selection of decisions,
- the former of the new generation,
- the new generation again goes through the selection.

### Algorithm implementation

Resheniya predstavlyayut iz sebya fioletovykh sushchnostey, kotoryye dolzhny vyzhit', ikhniye deystviya opridilyayet vshitaya matritsa deystviy razmerami 16 na 16, matritsa i yest' ikh genom kotoriy izmenyayetsa v protsese yevolyutsii, iznachal'no sozdayotsa 128 sushnostey oni pomeshchayutsa na pole, na pole yest' yeda, ani dalzhni vizhit' kak mozhno dol'she, yesle vse boti umerayut simulyatsiya perezapuchkayetsa,
yesle sushtnost' smogla vizhit', i sozhrat' mnogo yedi, to ana dast potomstvo, yest' shas chto potomok budet imen' mutatsii v matritse deystviy.
decisions are purple entities that must survive, their actions are determined by a sewn-in matrix of actions with dimensions of 16 by 16, the matrix is ​​their genome, which is a changer in the process of evolution, initially creating 128 entities, they are placed on the field, there is food on the field, and they must live as long as possible, if all the bots die reboot simulation,
If the entity could survive and devour a lot of food, then ana will give offspring, there is a chance that the offspring will be the name of the mutation in the matrix of actions.

### Resurces

<div>https://www.youtube.com/watch?v=9BajDA6ceTU&ab_channel=DimPy - python implementation</div>
https://www.youtube.com/watch?v=SfEZSyvbj2w&ab_channel=foo52ru%D0%A2%D0%B5%D1%85%D0%BD%D0%BE%D0%A8%D0%B0%D0%BC%D0%B0%D0%BD - realization from a technoshaman
