import './Footer.css'
import  { FooterNav } from './FooterNav';

export function Footer () 
{  
   return(<div>
    <div className="coloredCornerLeft" style={{position:'relative', zIndex: 0}}></div>
    
    <div className="Footer"></div>
    <FooterNav />
    </div>
   ); 
}

