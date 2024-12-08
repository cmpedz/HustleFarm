"use client";

import { useActiveAccount } from "thirdweb/react";
import { LoginButton } from "./consts/LoginButton";
import { Link, Element } from "react-scroll";
import { useState } from 'react';
import { Righteous, Fredoka } from 'next/font/google';

const righteous = Righteous({
  subsets: ['latin'],
  weight: "400"
});

const fredoka = Fredoka({
  subsets: ['latin'],
  weight: ["400", "600", "700"],
});

const scrollToElement = (elementClass: string) => {
  const element = document.querySelector(`.${elementClass}`);
  if (element) {
    const { top } = element.getBoundingClientRect();
    const scrollTo = top + window.scrollY; 
    window.scrollTo({ top: scrollTo, behavior: 'smooth' });
  }
};
  
export default function Home() {
  const account = useActiveAccount();
  const [isCopied, setIsCopied] = useState(false);

  const handleCopy = () => {
    navigator.clipboard.writeText('0xb99192491aB525d7b1775b95A2560b8095B89B89'); // Thay bằng mã hợp đồng token thực tế
    setIsCopied(true);
    setTimeout(() => setIsCopied(false), 2000); // Hiển thị thông báo đã sao chép trong 2 giây
  };
  return (
    <div className={`flex flex-col w-screen min-h-screen ${righteous.className}`}>
      {/* Header - Font mới */}
      <header className="bg-gradient-to-r from-green-700 to-blue-600 text-white p-4 fixed top-0 w-screen z-50 backdrop-blur-sm bg-opacity-95 rounded-b-xl">
        <div className="container mx-auto flex justify-between items-center">
          <div className={`text-2xl font-bold hover:scale-105 transition-all duration-300 ml-16 ${fredoka.className}`}>
              HustleFarm
          </div>
          
          {/* Navigation Menu - Font mới */}
          <nav className="inline space-x-6">
            <Link to="gameinfo" smooth={true} duration={500}>
              <span className="hover:text-yellow-200 transition-all duration-300 cursor-pointer font-semibold">
                Game Info
              </span>
            </Link>
            <Link to="features" smooth={true} duration={500}>
              <span className="hover:text-yellow-200 transition-all duration-300 cursor-pointer font-semibold">
                Features
              </span>
            </Link>
            <a href="/whitepaper" target="_blank" rel="noopener noreferrer">
              <span className="hover:text-yellow-200 transition-all duration-300 cursor-pointer font-semibold">
                White Paper
              </span>
            </a>
            <Link to="roadmap" smooth={true} duration={500}>
              <span className="hover:text-yellow-200 transition-all duration-300 cursor-pointer font-semibold">
                Road Map
              </span>
            </Link>
            <Link to="community" smooth={true} duration={500}>
              <span className="hover:text-yellow-200 transition-all duration-300 cursor-pointer font-semibold">
                Community
              </span>
            </Link>
            <Link to="tokenomics" smooth={true} duration={500}>
              <span className="hover:text-yellow-200 transition-all duration-300 cursor-pointer font-semibold">
                Tokenomics
              </span>
            </Link>
            <Link to="marketplace" smooth={true} duration={500}>
              <span className="hover:text-yellow-200 transition-all duration-300 cursor-pointer font-semibold">
                Marketplace
              </span>
            </Link>
            <Link to="testimonials" smooth={true} duration={500}>
              <span className="hover:text-yellow-200 transition-all duration-300 cursor-pointer font-semibold">
                Testimonials
              </span>
            </Link>
            <Link to="faq" smooth={true} duration={500}>
              <span className="hover:text-yellow-200 transition-all duration-300 cursor-pointer font-semibold">
                FAQ
              </span>
            </Link>
          </nav>
          
          <button className="lg:hidden text-white">
            <svg className="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M4 6h16M4 12h16m-16 6h16" />
            </svg>
          </button>
        </div>
      </header>

      {/* Game Information Section - Font mới */}
      <Element name="gameinfo" className="min-h-screen pt-20 sticky top-0">
        <div className="relative bg-cover bg-center py-20  w-screen h-screen linear-gradient(rgba(0,0,0,0.5), rgba(0,0,0,0.5)), bg-[url('/image/784ca092-400b-43e7-96f8-3588b6f8cad0.jpg')]">
          <div className="container mx-auto px-4">
            <div className="max-w-4xl mx-auto bg-white/10 backdrop-blur-md p-8 rounded-xl border border-white/20">
              <h2 className={`text-5xl text-center text-yellow-300 mb-8 font-bold ${fredoka.className}`}>
                Game Overview
              </h2>
              <div className="space-y-6 text-white">
                <p className="text-xl animate-fadeIn">
                  Welcome to the exciting world of Farm to Earn!
                </p>
                <p className="text-lg animate-fadeIn delay-200">
                  Engage in farming, animal husbandry, and more. Build your farm, trade with others, and earn rewards.
                </p>
                <div className="flex justify-center mt-8">
                    <div className="mx-auto bg-gradient-to-r from-yellow-500 to-yellow-600 text-white px-8 py-3 rounded-full hover:scale-105 transition-all duration-300 pt-8">
                    <p>Start Farming Now</p>
                    <div className="absolute inset-0 opacity-0">
                        <LoginButton />
                    </div>
                    </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </Element>

      {/* Features Section - Font mới */}
      <Element name="features" className="min-h-screen bg-gradient-to-b from-green-900 to-green-700  sticky top-1">
        <div className="container mx-auto px-4 py-20">
          <h2 className={`text-4xl text-center text-yellow-300 mb-12 font-bold ${fredoka.className}`}>
            Key Features
          </h2>
          <div className="grid md:grid-cols-2 lg:grid-cols-4 gap-8">
            {/* Feature Cards */}
            <div className="bg-white/10 backdrop-blur-md p-6 rounded-xl border border-white/20 hover:scale-105 transition-all duration-300">
              <div className="text-4xl mb-4">🌾</div>
              <h3 className="text-xl text-yellow-300 mb-2">Farming</h3>
              <p className="text-gray-300">Diverse crops and animals to manage</p>
            </div>
            <div className="bg-white/10 backdrop-blur-md p-6 rounded-xl border border-white/20 hover:scale-105 transition-all duration-300">
              <div className="text-4xl mb-4">💰</div>
              <h3 className="text-xl text-yellow-300 mb-2">Play-to-earn Mechanics</h3>
              <p className="text-gray-300">Real rewards with play-to-earn mechanics</p>
            </div>
            <div className="bg-white/10 backdrop-blur-md p-6 rounded-xl border border-white/20 hover:scale-105 transition-all duration-300">
              <div className="text-4xl mb-4">🛒</div>
              <h3 className="text-xl text-yellow-300 mb-2">In-game Shop</h3>
              <p className="text-gray-300">Trading and upgrades in the game shop</p>
            </div>
            <div className="bg-white/10 backdrop-blur-md p-6 rounded-xl border border-white/20 hover:scale-105 transition-all duration-300">
              <div className="text-4xl mb-4">🏆</div>
              <h3 className="text-xl text-yellow-300 mb-2">Competitive Events</h3>
              <p className="text-gray-300">Community engagement and competitive events</p>
            </div>
            <div className="bg-white/10 backdrop-blur-md p-6 rounded-xl border border-white/20 hover:scale-105 transition-all duration-300">
              <div className="text-4xl mb-4">🔒</div>
              <h3 className="text-xl text-yellow-300 mb-2">Secure Wallet</h3>
              <p className="text-gray-300">Secure wallet integration for safe transactions</p>
            </div>
            <div className="bg-white/10 backdrop-blur-md p-6 rounded-xl border border-white/20 hover:scale-105 transition-all duration-300">
              <div className="text-4xl mb-4">🌍</div>
              <h3 className="text-xl text-yellow-300 mb-2">Global Leaderboard</h3>
              <p className="text-gray-300">Track top players on the global leaderboard</p>
            </div>
            <div className="bg-white/10 backdrop-blur-md p-6 rounded-xl border border-white/20 hover:scale-105 transition-all duration-300">
              <div className="text-4xl mb-4">🎉</div>
              <h3 className="text-xl text-yellow-300 mb-2">Seasonal Events</h3>
              <p className="text-gray-300">Unique rewards in seasonal events</p>
            </div>
            <div className="bg-white/10 backdrop-blur-md p-6 rounded-xl border border-white/20 hover:scale-105 transition-all duration-300">
              <div className="text-4xl mb-4">📈</div>
              <h3 className="text-xl text-yellow-300 mb-2">Real-time Market</h3>
              <p className="text-gray-300">Crop and animal trading in real-time market</p>
            </div>
          </div>
        </div>
      </Element>

      {/* Road Map Section */}
      <Element name="roadmap" className="sticky top-3">
        <div className="bg-gradient-to-b from-green-900 to-green-700 bg-cover bg-center py-20 text-white w-screen h-screen">
          <div className="container mx-auto px-4">
            <h2 className={`text-4xl font-bold mb-8 text-center ${fredoka.className}`}>Road Map</h2>
            <div className="max-w-4xl mx-auto grid grid-cols-1 md:grid-cols-2 gap-8">
              <div className="bg-white/10 backdrop-blur-md p-6 rounded-xl border border-white/20 hover:transform hover:scale-105 transition-all duration-300">
                <h3 className="text-2xl font-bold text-yellow-300 mb-4">2024</h3>
                <ul className="space-y-4">
                  <li className="flex items-center space-x-3">
                    <span className="text-yellow-300">Q1:</span>
                    <span>Beta release</span>
                  </li>
                  <li className="flex items-center space-x-3">
                    <span className="text-yellow-300">Q2:</span>
                    <span>Play-to-earn feature</span>
                  </li>
                  <li className="flex items-center space-x-3">
                    <span className="text-yellow-300">Q3:</span>
                    <span>Ecosystem expansion</span>
                  </li>
                  <li className="flex items-center space-x-3">
                    <span className="text-yellow-300">Q4:</span>
                    <span>Community events and updates</span>
                  </li>
                </ul>
              </div>
              <div className="bg-white/10 backdrop-blur-md p-6 rounded-xl border border-white/20 hover:transform hover:scale-105 transition-all duration-300">
                <h3 className="text-2xl font-bold text-yellow-300 mb-4">2025</h3>
                <ul className="space-y-4">
                  <li className="flex items-center space-x-3">
                    <span className="text-yellow-300">Q1-Q2:</span>
                    <span>Launch of mobile app</span>
                  </li>
                  <li className="flex items-center space-x-3">
                    <span className="text-yellow-300">Q3-Q4:</span>
                    <span>Introduction of virtual reality features</span>
                  </li>
                </ul>
              </div>
            </div>
          </div>
        </div>
      </Element>

      {/* Community Section */}
      <Element name="community" className="sticky top-4">
        <div className="bg-gradient-to-b from-green-900 to-green-700 bg-cover bg-center py-20 text-white w-screen h-screen">
          <div className="container mx-auto px-4">
            <h2 className={`text-4xl font-bold mb-8 text-center ${fredoka.className}`}>Join Our Community</h2>
            <div className="max-w-4xl mx-auto">
              <p className="text-xl mb-8 text-center">Connect with other players and stay updated!</p>
              <div className="grid grid-cols-3 gap-8 max-w-2xl mx-auto">
                <a href="https://discord.gg/fRdhKkGn" target="_blank" 
                   className="bg-white/10 backdrop-blur-md p-6 rounded-xl border border-white/20 hover:transform hover:scale-110 transition-all duration-300 flex flex-col items-center">
                  <img src="https://images.crunchbase.com/image/upload/c_pad,f_auto,q_auto:eco,dpr_1/v1440924046/wi1mlnkbn2jluko8pzkj.png" 
                       alt="Discord" 
                       className="w-16 h-16 mb-4" />
                  <span className="text-lg font-semibold">Discord</span>
                </a>
                
                <a href="https://x.com/22028191H82899" target="_blank"
                   className="bg-white/10 backdrop-blur-md p-6 rounded-xl border border-white/20 hover:transform hover:scale-110 transition-all duration-300 flex flex-col items-center">
                  <img src="https://img.freepik.com/free-vector/new-2023-twitter-logo-x-icon-design_1017-45418.jpg" 
                       alt="Twitter" 
                       className="w-16 h-16 mb-4" />
                  <span className="text-lg font-semibold">Twitter</span>
                </a>
                
                <a href="https://t.me/+-uErS7Or4Wg4MmNl" target="_blank"
                   className="bg-white/10 backdrop-blur-md p-6 rounded-xl border border-white/20 hover:transform hover:scale-110 transition-all duration-300 flex flex-col items-center">
                  <img src="https://static.vecteezy.com/system/resources/previews/023/986/679/original/telegram-logo-telegram-logo-transparent-telegram-icon-transparent-free-free-png.png" 
                       alt="Telegram" 
                       className="w-16 h-16 mb-4" />
                  <span className="text-lg font-semibold">Telegram</span>
                </a>
              </div>
            </div>
          </div>
        </div>
      </Element>
      {/* Tokenomics Section - Font mới */}
      <Element name="tokenomics" className="min-h-screen bg-gradient-to-b from-green-700 to-green-900  sticky top-2">
        <div className="container mx-auto px-4 py-20">
          <h2 className={`text-4xl text-center text-yellow-300 mb-12 font-bold ${fredoka.className}`}>
            Tokenomics
          </h2>
          <div className="grid md:grid-cols-2 gap-8">
            <div className="bg-white/10 backdrop-blur-md p-8 rounded-xl border border-white/20">
              <div className="space-y-4">
                <div className="flex items-center space-x-4 text-white">
                  <span className="text-2xl">💰</span>
                  <div>
                    <h3 className="text-xl text-yellow-300">Player Rewards</h3>
                    <p>40% of total supply</p>
                  </div>
                </div>
                <div className="flex items-center space-x-4 text-white">
                  <span className="text-2xl">💼</span>
                  <div>
                    <h3 className="text-xl text-yellow-300">Development</h3>
                    <p>30% of total supply</p>
                  </div>
                </div>
                <div className="flex items-center space-x-4 text-white">
                  <span className="text-2xl">🏢</span>
                  <div>
                    <h3 className="text-xl text-yellow-300">Marketing</h3>
                    <p>20% of total supply</p>
                  </div>
                </div>
                <div className="flex items-center space-x-4 text-white">
                  <span className="text-2xl">🔒</span>
                  <div>
                    <h3 className="text-xl text-yellow-300">Reserves</h3>
                    <p>10% of total supply</p>
                  </div>
                </div>
              </div>
            </div>
            <div className="bg-white/10 backdrop-blur-md p-8 rounded-xl border border-white/20">
              <h3 className="text-2xl text-yellow-300 mb-4">Token Contract</h3>
              <div className="flex items-center space-x-2 bg-white/5 p-4 rounded-lg gap-1">
                <p className="text-gray-300 text-sm break-all">
                  0xb99192491aB525d7b1775b95A2560b8095B89B89
                </p>
                <button
                  onClick={handleCopy}
                  className="bg-yellow-500 text-white px-4 py-2 rounded-lg hover:bg-yellow-600 transition-colors"
                >
                  {isCopied ? 'Copied!' : 'Copy'}
                </button>
                <a href="https://pancakeswap.finance/?outputCurrency=0x0E09FaBB73Bd3Ade0a17ECC321fD13a19e81cE82&inputCurrency=0xb99192491aB525d7b1775b95A2560b8095B89B89&fbclid=IwY2xjawGYdg1leHRuA2FlbQIxMAABHaMYmNYfDXioL0o3mpD2ye1pEAAeGVzDx-LF6Bpm4o2YcmtGQT5DlrmaxQ_aem_c3sgwaXgE5iy6JiMkoUHSQ" target="_blank" rel="noopener noreferrer">
                  <img src="https://saigontradecoin.com/wp-content/uploads/2022/11/PancakeSwap-Crypto-Logo-PNG-Images.png" alt="BSCScan" className="dex-icon" />
                </a>
              </div>
            </div>
          </div>
        </div>
      </Element>
      {/* Marketplace Section */}
      <Element name="marketplace" className="sticky top-6">
        <div className="bg-[url('/image/42e2b132-444f-4685-9ce9-b4aa4280b22f.jpg')] bg-cover bg-center py-20 text-white w-screen h-screen">
          <div className="grid justify-center space-x-4">
            <h2 className="text-4xl font-bold mb-4">Marketplace</h2>
            <a  href="https://www.okx.com/vi/web3/marketplace/nft/collection/bsc/b%E1%BB%99-s%C6%B0u-t%E1%BA%ADp-ng%E1%BB%B1a" target="_blank" rel="noopener noreferrer">
              <img src="https://pimwp.s3-accelerate.amazonaws.com/2023/11/Untitled_design_-_2023-11-29T152347.380-removebg-preview-1.png" alt="PancakeSwap" className="dex-icon" />
            </a>      
          </div>
          <p className="text-center text-lg mt-4">
            Explore the PancakeSwap NFT collection on OKX Marketplace. Get your hands on exclusive NFTs and rare items from the collection of unique digital assets!
          </p>
        </div>
      </Element>
      {/* Testimonials Section */}
      <Element name="testimonials" className="sticky top-7">
        <div className="bg-gradient-to-b from-green-900 to-green-700 bg-cover bg-center py-20 text-white w-screen h-screen">
          <div className="container mx-auto px-4">
            <h2 className={`text-4xl font-bold mb-8 text-center ${fredoka.className}`}>What Our Players Say</h2>
            <div className="max-w-4xl mx-auto grid grid-cols-1 md:grid-cols-2 gap-8">
              <div className="bg-white/10 backdrop-blur-md p-6 rounded-xl border border-white/20 hover:transform hover:scale-105 transition-all duration-300">
                <p className="text-lg italic mb-4">"This game has completely changed my perspective on farming games! The community is amazing!"</p>
                <div className="flex items-center space-x-4">
                  <div className="w-12 h-12 bg-yellow-300 rounded-full flex items-center justify-center text-green-800 font-bold">
                    H
                  </div>
                  <div>
                    <p className="font-bold">Hung</p>
                    <p className="text-sm text-yellow-300">Active Player</p>
                  </div>
                </div>
              </div>
              
              <div className="bg-white/10 backdrop-blur-md p-6 rounded-xl border border-white/20 hover:transform hover:scale-105 transition-all duration-300">
                <p className="text-lg italic mb-4">"I love the play-to-earn mechanics! It feels rewarding to invest my time."</p>
                <div className="flex items-center space-x-4">
                  <div className="w-12 h-12 bg-yellow-300 rounded-full flex items-center justify-center text-green-800 font-bold">
                    H
                  </div>
                  <div>
                    <p className="font-bold">Huy</p>
                    <p className="text-sm text-yellow-300">Active Player</p>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </Element>

      {/* FAQ Section */}
      <Element name="faq" className="sticky top-8">
        <div className="bg-gradient-to-b from-green-900 to-green-700 bg-cover bg-center py-20 text-white w-screen h-screen">
          <div className="container mx-auto px-4">
            <h2 className={`text-4xl font-bold mb-8 text-center ${fredoka.className}`}>Frequently Asked Questions</h2>
            <div className="max-w-4xl mx-auto space-y-6">
              <div className="bg-white/10 backdrop-blur-md p-6 rounded-xl border border-white/20 hover:transform hover:scale-105 transition-all duration-300">
                <h3 className="text-xl font-bold text-yellow-300 mb-2">How do I start playing?</h3>
                <p>Simply create an account, and you're ready to start your farming adventure!</p>
              </div>
              
              <div className="bg-white/10 backdrop-blur-md p-6 rounded-xl border border-white/20 hover:transform hover:scale-105 transition-all duration-300">
                <h3 className="text-xl font-bold text-yellow-300 mb-2">Is there a mobile version?</h3>
                <p>Yes! We are planning to release a mobile app in 2025.</p>
              </div>
              
              <div className="bg-white/10 backdrop-blur-md p-6 rounded-xl border border-white/20 hover:transform hover:scale-105 transition-all duration-300">
                <h3 className="text-xl font-bold text-yellow-300 mb-2">Can I earn real money?</h3>
                <p>Absolutely! Our play-to-earn model allows players to earn cryptocurrency rewards.</p>
              </div>
            </div>
          </div>
        </div>
      </Element>
      {/* Footer - Font mới */}
      <footer className="bg-gradient-to-r from-green-900 to-green-800 text-white py-8 z-50">
        <div className="container mx-auto px-4 text-center">
          <p className={`text-xl mb-4 ${fredoka.className} font-semibold`}>&copy; 2024 Farm to Earn</p>
          <div className="flex justify-center space-x-6">
            <a href="/privacy" className="text-gray-300 hover:text-yellow-300 transition-colors" target="_blank">
              Privacy Policy
            </a>
            <a href="/terms" className="text-gray-300 hover:text-yellow-300 transition-colors" target="_blank">
              Terms of Service
            </a>
          </div>
        </div>
      </footer>

      {/* Global Styles */}
      <style jsx global>{`
        @keyframes fadeIn {
          from { opacity: 0; transform: translateY(20px); }
          to { opacity: 1; transform: translateY(0); }
        }

        .animate-fadeIn {
          animation: fadeIn 1s ease-out forwards;
        }

        .delay-200 {
          animation-delay: 200ms;
        }

        .community-icon {
          width: 48px;
          height: 48px;
          transition: transform 0.3s;
        }

        .community-icon:hover {
          transform: scale(1.2);
        }

        .dex-icon {
          width: 200px;
          height: 120px;
          transition: transform 0.3s;
        }

        .dex-icon:hover {
          transform: scale(1.1);
        }
      `}</style>
    </div>
  );
}
