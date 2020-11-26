import React from 'react';
import { View, Image, Text } from 'react-native';
import { RectButton } from 'react-native-gesture-handler';

import heartOutlineIcon from '../../assets/images/icons/heart-outline.png';
import unfavoriteIcon from '../../assets/images/icons/unfavorite.png';
import whatsappIcon from '../../assets/images/icons/whatsapp.png';


import styles from './styles';

function TeacherItem() {
  return (
    <View style={styles.container}>
      <View style={styles.profile}>
        <Image
          style={styles.avatar}
          source={{ uri: "https://www.chevrolet.com.br/content/dam/chevrolet/mercosur/brazil/portuguese/index/cars/cars-subcontent/04-images/novo-onix-branco-summit.png?imwidth=960" }}
        />

        <View style={styles.profileInfo}>
          <Text style={styles.name}>Vitor Lopes </Text>
          <Text style={styles.subject}> História </Text>
        </View>
      </View>

      <Text style={styles.bio}>
        Suspendisse eget facilisis justo. {'\n'}{'\n'}
        In mollis lacinia tellus vel consectetur. Fusce ut sem odio. Fusce at pretium elit. Integer viverra non felis non rutrum.
       </Text>

       <View style={styles.footer}>
          <Text style={styles.price}>
            Preço/hora {'    '}
            <Text style={styles.priceValue}>R$ 20,00</Text>
          </Text>
       </View>

       <View style={styles.buttonsContainer}>
          <RectButton style={[styles.favoriteButton, styles.favorited]}>
           {/* <Image source={heartOutlineIcon} />  */}
           <Image source={unfavoriteIcon} /> 

          </RectButton>

          <RectButton style={styles.contactButton}>
           <Image source={whatsappIcon} />
           <Text style={styles.contactButtonText}>Entrar em contato</Text> 
          </RectButton>         
       </View>
    </View>
  );
}

export default TeacherItem;