import './Footer.css'

 export function FooterNav()
{
    return(
        <div className="Footer-nav">
            <nav>
                <a href="#/PrivacyPolicy">Privacybeleid</a> 
                <a href="https://www.accessibility.nl/" target="_blank">Website stichting accessibility</a> 
            </nav>
            <span>
                <a href='tel:+030-2398270"'>Telefoonnummer: 030-2398270</a>
                <a href='mailto: info@accessibility.nl'>Email: info@accessibility.nl</a>
                <a href='https://www.google.com/maps/place/Christiaan+Krammlaan+2,+3571+AX+Utrecht/@52.1087143,5.1185818,17z/data=!3m1!4b1!4m6!3m5!1s0x47c66f3b97fb2a95:0x30cf938aa1cf68a9!8m2!3d52.108711!4d5.1211567!16s%2Fg%2F11b8v4bc8_?entry=ttu' target="_blank">Adres: Christiaan Krammlaan 2, 3571 AX Utrecht</a>
            </span>
    </div>
    );
}