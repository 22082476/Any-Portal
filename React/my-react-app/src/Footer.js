import './Footer.css'
import FooterNav from './FooterNav';

function Footer () 
{  
   return(<div>
    <div className="coloredCornerLeft" zIndex={0} style={{position:'relative'}}></div>
    <div className="Footer"></div>
    <FooterNav />
    </div>
   ); 
}

export default Footer;

